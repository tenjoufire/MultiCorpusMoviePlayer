using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiCorpusMoviePlayer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //ストーリーボード
        Storyboard storyboard = null;

        string fileName = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayMovie()
        {
            //メディアタイムラインを作成
            MediaTimeline mediaTimeline = new MediaTimeline(new Uri(fileName));
            mediaTimeline.CurrentTimeInvalidated += new EventHandler(mediaTimeline_CurrentTimeInvalidated);
            Storyboard.SetTargetName(mediaTimeline, MoviePlayer.Name);

            //ストーリーボードを作成・開始
            storyboard = new Storyboard();
            storyboard.Children.Add(mediaTimeline);
            storyboard.Begin(this, true);

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            //ファイルを開くダイアログボックスを表示
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "動画ファイル(*.avi;*.wmv;*.mpg;*.mpeg;*.mp4;*.mkv;*.m2ts;*.flv)|*.avi;*.wmv;*.mpg;*.mpeg;*.mp4;*.mkv;*.m2ts;*.flv";
            if (openFileDialog.ShowDialog() != true)
                return;

            //ファイル名を保存する
            fileName = openFileDialog.FileName;
            //開いたファイルを表示
            FileName.Text = fileName.Split("\\"[0]).LastOrDefault();

            PlayMovie();
        }

        private void mediaTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {

        }
    }
}
