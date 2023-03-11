using CharacterRecognitionPerceptron.Common;
using CharacterRecognitionPerceptron.Utils;
using System.Drawing.Imaging;

namespace CharacterRecognitionPerceptron
{
    public partial class MainForm : Form
    {
        int _x = -1;
        int _y = -1;
        bool mouseMove = false;
        
        Graphics _canvas;
        Pen _pen;
        Bitmap _bmp;
        Perceptron perceptron;

        private Task? _trainTask;
        private CancellationTokenSource? _ctsAuto;

        public MainForm()
        {
            InitializeComponent();
            perceptron = new Perceptron(225, 0.01, 1, true);
            learningRate.Text = perceptron.LearningRate.ToString();

            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            _canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _canvas.Clear(Color.White);
            
            canvasContainer.Image = _bmp;
          
            _pen = new Pen(Color.Black, 35);
            _pen.StartCap = _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void CanvasContainer_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = true;
            _x = e.X;
            _y = e.Y;
            canvasContainer.Cursor = Cursors.Cross;
        }

        private void CanvasContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove && _x != -1 && _y != -1)
            {
                _canvas.DrawLine(_pen, new Point(_x, _y), e.Location);
                _x = e.X;
                _y = e.Y;
            }
            canvasContainer.Refresh();
        }

        private void CanvasContainer_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = false;
            _x = -1;
            _y = -1;
            canvasContainer.Cursor = Cursors.Default;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            pictureBox.Image = null;
        }

        private void ClearCanvas()
        {
            canvasContainer.Image = null;
            _bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            _canvas = Graphics.FromImage(_bmp);
            canvasContainer.Image = _bmp;
            _canvas.Clear(Color.White);
            predictedOutput.Text = string.Empty;
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            ProcessImage();
        }
        
        private void ProcessImage()
        {
            var ms = new MemoryStream();
            var bmp = new Bitmap(canvasContainer.Width, canvasContainer.Height);

            canvasContainer.DrawToBitmap(bmp, new Rectangle(0, 0, canvasContainer.Width, canvasContainer.Height));
            //bmp.Save(Path.Combine(AppContext.BaseDirectory, "images", $"original-{TimeStamp.GetUTCNow()}-{labelY.Text}.png"), ImageFormat.Png);

            var image = DIP.ResizeImage(bmp, 15, 15);
            //image.Save(Path.Combine(AppContext.BaseDirectory, "images", $"{TimeStamp.GetUTCNow()}-{labelY.Text}.png"), ImageFormat.Png);
            image.Save(ms, ImageFormat.Png);

            pictureBox.Image = image;
            predictedOutput.Text = perceptron.Prediction(DIP.GetBits(ms));
        }

        private async Task Train(CancellationToken token)
        {
            var images = Directory.GetFiles(dataSetPath.Text, "*.png")
                            .Where(file => !file.Contains("original"))
                            .ToArray();

            var originalImages = Directory.GetFiles(dataSetPath.Text, "*.png")
                           .Where(file => file.Contains("original"))
                           .ToArray();
            
            var imageDictionary = new Dictionary<string, string>();
            for (int i = 0; i < images.Length; i++)
            {
                imageDictionary.Add(images[i], originalImages[i]);
            }

            // Shuffle data set to avoid overfitting
            var rand = new Random();
            imageDictionary = imageDictionary.OrderBy(x => rand.Next()).ToDictionary(x => x.Key, x => x.Value);

            images = imageDictionary.Keys.ToArray();
            originalImages = imageDictionary.Values.ToArray();

            int countEpoch = 0;
            for (int i = 0; i < Convert.ToInt32(epochsInput.Text) && !token.IsCancellationRequested; i++)
            {
                for (int j = 0; j < images.Length && !token.IsCancellationRequested; j++)
                {
                    dataSetsFeed.Invoke(new Action(() =>
                    {
                        dataSetsFeed.Items.Add($"Img: {Path.GetFileNameWithoutExtension(images[j])}   T: {Math.Abs(perceptron.TotalError)}");
                        dataSetsFeed.SelectedIndex = dataSetsFeed.Items.Count - 1;
                    }));     

                    var x = new MemoryStream();
                    var image = Image.FromFile(images[j]);
                    image.Save(x, ImageFormat.Png);

                    var y = int.Parse(Path.GetFileNameWithoutExtension(images[j]).Last().ToString());

                // Set Perceptron Input and DesiredOutput Here
                // ----------------------------------------
                    perceptron.SetInput(DIP.GetBits(x));
                    perceptron.SetDesiredOutput(y);
                    perceptron.Learn();
                // ----------------------------------------

                    pictureBox.Image = image;
                    _canvas = Graphics.FromImage(Image.FromFile(originalImages[j]));
                    canvasContainer.Image = Image.FromFile(originalImages[j]);
                }

                if (Math.Abs(perceptron.TotalError) < 0.01)
                {
                    _ctsAuto!.Cancel();
                    break;
                }
                
                countEpoch++;
            }

            epochsLabel.Invoke(new Action(() =>
            {
                epochsLabel.Text = $"Epochs: {countEpoch}";
            }));

            totalErrorLabel.Invoke(new Action(() =>
            {
                totalErrorLabel.Text = $"Total Error: {Math.Abs(perceptron.TotalError).ToString()}";
            }));
        }

        private async void trainBtn_Click(object sender, EventArgs e)
        {
            if (dataSetPath.Text.Contains("No data set loaded"))
            {
                MessageBox.Show("Please select a data set first", "No data set loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            
            trainBtn.Enabled = false;
            resetPerceptronModel.Enabled = false;
            learningRateTrackbar.Enabled = false;
            epochsInput.Enabled = false;

            _ctsAuto = new CancellationTokenSource();
            _trainTask = await Task.Factory.StartNew(async () =>
            {
                try
                {
                    await Train(_ctsAuto!.Token);
                } 
                catch { }
                finally
                {
                    _ctsAuto?.Dispose();
                    _ctsAuto = null;
                }
            }, _ctsAuto!.Token);

            await ForTrueAsync(() => _ctsAuto is null, 20);

            trainBtn.Enabled = true;
            resetPerceptronModel.Enabled = true;
            learningRateTrackbar.Enabled = true;
            epochsInput.Enabled = true;
        }

        private void learningRateTrackbar_Scroll(object sender, EventArgs e)
        {
            double toDecimal = (double)learningRateTrackbar.Value / 1000;
            learningRate.Text = toDecimal.ToString();
            perceptron.LearningRate = toDecimal;
        }

        private void resetPerceptronModel_Click(object sender, EventArgs e)
        {
            perceptron = new Perceptron(225, double.Parse(learningRate.Text), 1, true);
            totalErrorLabel.Text = "Total Error:";
            epochsLabel.Text = $"Epochs:";
            dataSetsFeed.Items.Clear();
        }

        private void randCharImageBtn_Click(object sender, EventArgs e)
        {
            if (dataSetPath.Text.Contains("No data set loaded"))
            {
                MessageBox.Show("Please select a data set first", "No data set loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
                
            var images = Directory.GetFiles(dataSetPath.Text, "*.png")
                            .Where(file => file.Contains("original"))
                            .ToArray();

            var rand = new Random();

            var image = Image.FromFile(images[rand.Next(0, images.Length)]);
            _canvas = Graphics.FromImage(image);
            canvasContainer.Image = image;
        }

        private void loadDataSetBtn_Click(object sender, EventArgs e)
        {
            // open file dialog and select directory only
            using var fbd = new FolderBrowserDialog();
            fbd.Description = "Select the directory that contains the images";
            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            dataSetPath.Text = fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : string.Empty;
        }

        private async void stopTraining_Click(object sender, EventArgs e)
        {
            _ctsAuto?.Cancel();
            await ForTrueAsync(() => _ctsAuto is null, 20);
            _trainTask?.Dispose();
            
            trainBtn.Enabled = true;
            resetPerceptronModel.Enabled = true;
            learningRateTrackbar.Enabled = true;
            epochsInput.Enabled = true;
        }

        public async ValueTask<bool> ForTrueAsync(Func<bool> predicate, int timeout, int sleepOverride = -1, CancellationToken token = default)
        {
            return await ForTrueAsync(predicate, null, timeout, sleepOverride, token);
        }

        private async ValueTask<bool> ForTrueAsync(Func<bool> predicate, Action? loopFunction, int timeout, int sleepOverride = -1, CancellationToken token = default)
        {
            try
            {
                int counter = 0;
                while (!predicate() && !token.IsCancellationRequested)
                {
                    if (timeout > 0 && counter >= timeout)
                        return false;
                    loopFunction?.Invoke();
                    await Task.Delay(sleepOverride == -1 ? 20 : sleepOverride, token);
                    counter++;
                }
                return true;
            }
            catch { }
            return false;
        }
    }
}