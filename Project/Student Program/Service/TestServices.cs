using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Student_Program.Models;

namespace Student_Program.Service
{
    public class TestServices
    {
        private ConnectService _connectService;
        public int PageNumber { get; set; } = 1;
        private int _typeNumber;

        public TestServices(ConnectService connectService){ _connectService = connectService;}

        public async Task GetPage(WrapPanel wrapPanel, int number)
        {
            if (PageNumber == 1)
                await GetFirstPage(wrapPanel);
            else if (PageNumber == 2)
                await GetSecondPage(wrapPanel, number);
        }

        //FirstPage
        #region
        private async Task GetFirstPage(WrapPanel wrapPanel)
        {
            wrapPanel.Children.Clear();

            var command = new Command() { UserCommand = UserCommandServer.GetListTests, Id = _connectService.Id };
            _connectService.SendCommand(command);
            var res = (await _connectService.ReadCommand()).Tests;

            if (res != null)
            {
                foreach (var item in res)
                {
                    wrapPanel.Children.Add(new Border()
                    {
                        Tag = item.Id,
                        CornerRadius = new System.Windows.CornerRadius(5),
                        BorderThickness = new Thickness(2),
                        Margin = new Thickness(10),
                        Height = 250,
                        Width = 650,
                        BorderBrush = Brushes.Black,
                        Background = (Brush)new BrushConverter().ConvertFrom("#FFD6F3EF")
                    });
                }

                foreach (var item in wrapPanel.Children)
                {
                    if (item is Border border)
                    {
                        border.MouseDown += MouseDownBorder;
                        border.Child = new Grid();
                        if (border.Child is Grid grid)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.75, GridUnitType.Star) });
                            grid.ColumnDefinitions.Add(new ColumnDefinition());
                            Image image = new Image();
                            try
                            {
                                image.Margin = new Thickness(5);
                                image.Stretch = Stretch.UniformToFill;
                                image.Source = new BitmapImage(new Uri($"{res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().ImagePath}"));
                            }
                            catch (Exception) { }
                            finally { grid.Children.Add(image); }

                            TextBlock textBlock = new TextBlock()
                            {
                                TextWrapping = TextWrapping.Wrap,

                                FontSize = 40,
                                HorizontalAlignment = HorizontalAlignment.Stretch,
                                VerticalAlignment = VerticalAlignment.Center,
                                FontWeight = FontWeights.Bold,
                                FontStyle = FontStyles.Italic,
                                FontFamily = new FontFamily("Segoe Print"),
                                TextAlignment = TextAlignment.Center,
                                Text = res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().TestName
                            };
                            Grid.SetColumn(textBlock, 1);
                            grid.Children.Add(textBlock);

                            TextBlock textBlockSubject = new TextBlock()
                            {
                                TextWrapping = TextWrapping.Wrap,

                                FontSize = 14,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Bottom,
                                FontWeight = FontWeights.Bold,
                                FontStyle = FontStyles.Italic,
                                FontFamily = new FontFamily("Segoe Print"),
                                TextAlignment = TextAlignment.Center,
                                Text = res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().Teacher.Subject,
                                Margin = new Thickness(5, 0, 0, 5)
                            };
                            Grid.SetColumn(textBlockSubject, 1);
                            grid.Children.Add(textBlockSubject);

                            TextBlock textBlockTeacherFullName = new TextBlock()
                            {
                                TextWrapping = TextWrapping.Wrap,

                                FontSize = 14,
                                HorizontalAlignment = HorizontalAlignment.Right,
                                VerticalAlignment = VerticalAlignment.Bottom,
                                FontWeight = FontWeights.Bold,
                                FontStyle = FontStyles.Italic,
                                FontFamily = new FontFamily("Segoe Print"),
                                TextAlignment = TextAlignment.Center,
                                Text = res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().Teacher.FullName,
                                Margin = new Thickness(0, 0, 10, 5)
                            };
                            Grid.SetColumn(textBlockTeacherFullName, 1);
                            grid.Children.Add(textBlockTeacherFullName);
                        }
                    }
                }
            }
            else MessageBox.Show("Сервер не отвечает");
        }
        #endregion

        //GetSecondPage
        #region
        private async Task GetSecondPage(WrapPanel wrapPanel, int number)
        {
            wrapPanel.Children.Clear();

            var command = new Command() { UserCommand = UserCommandServer.GetTest, Id = _connectService.Id, Test = new ViewModels.TestViewModel() { Id = number } };
            _connectService.SendCommand(command);
            var res = (await _connectService.ReadCommand()).Test;

            foreach (var item in res.Questions)
            {
                wrapPanel.Children.Add(new Border()
                {
                    Tag = item.Id,
                    CornerRadius = new System.Windows.CornerRadius(5),
                    BorderThickness = new Thickness(2),
                    Margin = new Thickness(15),
                    BorderBrush = Brushes.Black,
                    Background = (Brush)new BrushConverter().ConvertFrom("#FFD6F3EF"),
                });
            }

            foreach (var item in wrapPanel.Children)
            {
                if (item is Border border)
                {
                    border.MouseDown += MouseDownBorder;
                    border.Child = new GroupBox();
                    if (border.Child is GroupBox groupBox)
                    {
                        groupBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF12063A");
                        groupBox.Width = 350;

                        groupBox.Header = new TextBlock()
                        {
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Text = res.Questions.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().QuestionText,
                            Background = (Brush)new BrushConverter().ConvertFrom("#FF12063A"),
                            Foreground = Brushes.White,
                            TextWrapping = TextWrapping.Wrap,
                            Margin = new Thickness(-4)
                        };

                        groupBox.Content = new StackPanel();

                        if (groupBox.Content is StackPanel stackPanel)
                        {
                            stackPanel.VerticalAlignment = VerticalAlignment.Center;
                            try
                            {
                                stackPanel.Children.Add(new Image()
                                {
                                    Margin = new Thickness(5),
                                    Stretch = Stretch.Uniform,
                                    Source = new BitmapImage(new Uri($"{res.Questions.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().ImagePath}")),
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                    Width = 250
                                });
                            }
                            catch (Exception) { }

                            var answers = res.Questions.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().Answers;
                            int count = 0;
                            foreach (var answer in answers)
                                if (answer.Right)
                                    count++;

                            if (count == 1)
                            {
                                foreach (var answer in answers)
                                {
                                    stackPanel.Children.Add(new RadioButton()
                                    {
                                        Content = new TextBlock()
                                        {
                                            TextWrapping = TextWrapping.Wrap,
                                            Text = answer.ResponseText,                                          
                                        },
                                        Background=Brushes.Transparent,
                                        Margin = new Thickness(5)
                                    });
                                }
                            }
                            else if (count > 1)
                            {
                                foreach (var answer in answers)
                                {
                                    stackPanel.Children.Add(new CheckBox()
                                    {
                                        Content = new TextBlock()
                                        {
                                            TextWrapping = TextWrapping.Wrap,
                                            Text = answer.ResponseText
                                        },
                                        Margin = new Thickness(5)
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private async void MouseDownBorder(object sender, MouseButtonEventArgs e)
        {
            var res = sender as Border;
            var ress = res.Parent as WrapPanel;

            if (PageNumber == 1)
                _typeNumber = Convert.ToInt32(res.Tag);

            if (PageNumber == 2) return;

            PageNumber++;

            await GetPage(ress, Convert.ToInt32(res.Tag));
        }
    }
}