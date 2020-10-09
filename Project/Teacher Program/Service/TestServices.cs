using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Teacher_Program.Models;

namespace Teacher_Program.Service
{
    public class TestServices
    {
        private ConnectService _connectService;
        public int PageNumber { get; set; } = 1;
        private int _typeNumber;

        public TestServices(ConnectService connectService) { _connectService = connectService; }

        public async Task GetPage(WrapPanel wrapPanel, int number)
        {
            if (PageNumber == 1)
                await GetFirstPage(wrapPanel);
            else if (PageNumber == 2)
                await GetSecondPage(wrapPanel, number);
        }

        //FirstPage

        private async Task GetFirstPage(WrapPanel wrapPanel)
        {
            wrapPanel.Children.Clear();

            var command = new Command() { AdminCommand = AdminCommandServer.GetListTests, Id = _connectService.Id };
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

                            //Button butt = new Button();
                            //butt.Tag = border.Tag;
                            //butt.HorizontalAlignment = HorizontalAlignment.Right;
                            //butt.VerticalAlignment = VerticalAlignment.Bottom;
                            //butt.Background = Brushes.Transparent;
                            //butt.BorderBrush = Brushes.Transparent;
                            //butt.Margin = new Thickness(5);
                            //butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Add_document_icon_%28the_Noun_Project_27896%29_blue.svg/1200px-Add_document_icon_%28the_Noun_Project_27896%29_blue.svg.png")), MaxHeight = 30, Stretch = Stretch.Uniform };
                            //butt.Click += ButtonClickAnimal;
                            //Grid.SetColumn(butt, 1);
                            //grid.Children.Add(butt);
                        }
                    }
                }
                //Button button = new Button();
                //button.HorizontalAlignment = HorizontalAlignment.Right;
                //button.VerticalAlignment = VerticalAlignment.Bottom;
                //button.Background = Brushes.Transparent;
                //button.BorderBrush = Brushes.Transparent;
                //button.Margin = new Thickness(5, 5, 55, 5);
                //button.Content = new Image() { Source = new BitmapImage(new Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Add_document_icon_%28the_Noun_Project_27896%29_blue.svg/1200px-Add_document_icon_%28the_Noun_Project_27896%29_blue.svg.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
                //button.Click += ButtonClickAddTypedAnimal;
                //wrapPanel.Children.Add(button);
            }
            else MessageBox.Show("Сервер не отвечает");
        }

        ////AddTypedAnimal
        //#region
        //private void ButtonClickAddTypedAnimal(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Button button && button.Parent is WrapPanel wrapPanel)
        //    {
        //        PageNumber++;
        //        wrapPanel.Children.Clear();

        //        wrapPanel.Children.Add(new Border()
        //        {
        //            CornerRadius = new System.Windows.CornerRadius(5),
        //            BorderThickness = new Thickness(2),
        //            Margin = new Thickness(10),
        //            Height = 200,
        //            Width = 600,
        //            BorderBrush = Brushes.Black,
        //            Background = (Brush)new BrushConverter().ConvertFrom("#FF4FB7BA"),
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Center
        //        });

        //        foreach (var item in wrapPanel.Children)
        //        {
        //            if (item is Border border)
        //            {
        //                border.Child = new Grid();
        //                if (border.Child is Grid grid)
        //                {
        //                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.4, GridUnitType.Star) });
        //                    grid.ColumnDefinitions.Add(new ColumnDefinition());

        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition());


        //                    TextBlock textBlock1 = new TextBlock() { Margin = new Thickness(5), Text = "Название вида", FontSize = 16 };
        //                    grid.Children.Add(textBlock1);
        //                    TextBox textBox = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "1", FontSize = 16 };
        //                    Grid.SetColumn(textBox, 1);
        //                    grid.Children.Add(textBox);

        //                    TextBlock textBlock2 = new TextBlock() { Margin = new Thickness(5), Text = "Адрес изображения", FontSize = 16 };
        //                    Grid.SetRow(textBlock2, 1);
        //                    grid.Children.Add(textBlock2);
        //                    TextBox textBox2 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "2", FontSize = 16 };
        //                    Grid.SetColumn(textBox2, 1);
        //                    Grid.SetRow(textBox2, 1);
        //                    grid.Children.Add(textBox2);
        //                }
        //            }

        //        }
        //        Button butt = new Button();
        //        butt.HorizontalAlignment = HorizontalAlignment.Right;
        //        butt.VerticalAlignment = VerticalAlignment.Bottom;
        //        butt.Background = Brushes.Transparent;
        //        butt.BorderBrush = Brushes.Transparent;
        //        butt.Margin = new Thickness(5, 5, 55, 5);
        //        butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Add_document_icon_%28the_Noun_Project_27896%29_blue.svg/1200px-Add_document_icon_%28the_Noun_Project_27896%29_blue.svg.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
        //        butt.Click += SaveTypeAnimal;
        //        wrapPanel.Children.Add(butt);
        //    }
        //}

        //private async void SaveTypeAnimal(object sender, RoutedEventArgs e)
        //{
        //    var name = "";
        //    var path = "";
        //    if (sender is Button button)
        //    {
        //        if (button.Parent is WrapPanel wrapPanel)
        //        {
        //            foreach (var item in wrapPanel.Children)
        //            {
        //                if (item is Border border && border.Child is Grid grid)
        //                {
        //                    foreach (var itemGrid in grid.Children)
        //                    {
        //                        if (itemGrid is TextBox text)
        //                        {
        //                            if (text.Tag.ToString() == "1") name = text.Text;
        //                            if (text.Tag.ToString() == "2") path = text.Text;
        //                        }
        //                    }
        //                }
        //            }
        //            if (name != "" && path != "")
        //            {
        //                PageNumber = 1;
        //                await _repository.Add(new Domain.Model.TypeOfAnimal() { Name = name, PhotoPath = path });
        //                await GetPage(wrapPanel, 0);
        //            }
        //        }
        //    }
        //}
        //#endregion

        ////AddAnimal
        //#region
        //private void ButtonClickAnimal(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Button button && button.Parent is Grid grid1 && grid1.Parent is Border border1 && border1.Parent is WrapPanel wrapPanel)
        //    {
        //        _typeNumber = Convert.ToInt32(border1.Tag);
        //        PageNumber++;
        //        wrapPanel.Children.Clear();

        //        wrapPanel.Children.Add(new Border()
        //        {
        //            CornerRadius = new System.Windows.CornerRadius(5),
        //            BorderThickness = new Thickness(2),
        //            Margin = new Thickness(10),
        //            BorderBrush = Brushes.Black,
        //            MinHeight = 200,
        //            MinWidth = 500,
        //            Background = (Brush)new BrushConverter().ConvertFrom("#FF4FB7BA"),
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Center
        //        });

        //        foreach (var item in wrapPanel.Children)
        //        {
        //            if (item is Border border)
        //            {
        //                border.Child = new Grid();
        //                if (border.Child is Grid grid)
        //                {
        //                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.4, GridUnitType.Star) });
        //                    grid.ColumnDefinitions.Add(new ColumnDefinition());

        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        //                    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });


        //                    TextBlock textBlock1 = new TextBlock() { Margin = new Thickness(5), Text = "Название", FontSize = 16 };
        //                    grid.Children.Add(textBlock1);
        //                    TextBox textBox = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "1", FontSize = 16 };
        //                    Grid.SetColumn(textBox, 1);
        //                    grid.Children.Add(textBox);

        //                    TextBlock textBlock2 = new TextBlock() { Margin = new Thickness(5), Text = "Краткое описание", FontSize = 16 };
        //                    Grid.SetRow(textBlock2, 1);
        //                    grid.Children.Add(textBlock2);
        //                    TextBox textBox2 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "2", FontSize = 16 };
        //                    Grid.SetColumn(textBox2, 1);
        //                    Grid.SetRow(textBox2, 1);
        //                    grid.Children.Add(textBox2);

        //                    TextBlock textBlock3 = new TextBlock() { Margin = new Thickness(5), Text = "Описание", FontSize = 16 };
        //                    Grid.SetRow(textBlock3, 2);
        //                    grid.Children.Add(textBlock3);
        //                    TextBox textBox3 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "3", FontSize = 16 };
        //                    Grid.SetColumn(textBox3, 1);
        //                    Grid.SetRow(textBox3, 2);
        //                    grid.Children.Add(textBox3);


        //                    TextBlock textBlock4 = new TextBlock() { Margin = new Thickness(5), Text = "Внешний вид", FontSize = 16 };
        //                    Grid.SetRow(textBlock4, 3);
        //                    grid.Children.Add(textBlock4);
        //                    TextBox textBox4 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "4", FontSize = 16 };
        //                    Grid.SetColumn(textBox4, 1);
        //                    Grid.SetRow(textBox4, 3);
        //                    grid.Children.Add(textBox4);

        //                    TextBlock textBlock5 = new TextBlock() { Margin = new Thickness(5), Text = "Среда обитание", FontSize = 16 };
        //                    Grid.SetRow(textBlock5, 4);
        //                    grid.Children.Add(textBlock5);
        //                    TextBox textBox5 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "5", FontSize = 16 };
        //                    Grid.SetColumn(textBox5, 1);
        //                    Grid.SetRow(textBox5, 4);
        //                    grid.Children.Add(textBox5);

        //                    TextBlock textBlock6 = new TextBlock() { Margin = new Thickness(5), Text = "Адрес изображения", FontSize = 16 };
        //                    Grid.SetRow(textBlock6, 5);
        //                    grid.Children.Add(textBlock6);
        //                    TextBox textBox6 = new TextBox() { Margin = new Thickness(5), TextWrapping = TextWrapping.Wrap, Tag = "6", FontSize = 16 };
        //                    Grid.SetColumn(textBox6, 1);
        //                    Grid.SetRow(textBox6, 5);
        //                    grid.Children.Add(textBox6);
        //                }
        //            }

        //        }
        //        Button butt = new Button();
        //        butt.HorizontalAlignment = HorizontalAlignment.Right;
        //        butt.VerticalAlignment = VerticalAlignment.Bottom;
        //        butt.Background = Brushes.Transparent;
        //        butt.BorderBrush = Brushes.Transparent;
        //        butt.Margin = new Thickness(5, 5, 55, 5);
        //        butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Add_document_icon_%28the_Noun_Project_27896%29_blue.svg/1200px-Add_document_icon_%28the_Noun_Project_27896%29_blue.svg.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
        //        butt.Click += SaveAnimal;
        //        wrapPanel.Children.Add(butt);
        //    }
        //}

        //private async void SaveAnimal(object sender, RoutedEventArgs e)
        //{
        //    var Name = "";
        //    var ShortDescription = "";
        //    var Description = "";
        //    var Appearance = "";
        //    var Habitat = "";
        //    var ImagePath = "";
        //    int TypeOfAnimalId = _typeNumber;
        //    if (sender is Button button)
        //    {
        //        if (button.Parent is WrapPanel wrapPanel)
        //        {
        //            foreach (var item in wrapPanel.Children)
        //            {
        //                if (item is Border border && border.Child is Grid grid)
        //                {
        //                    foreach (var itemGrid in grid.Children)
        //                    {
        //                        if (itemGrid is TextBox text)
        //                        {
        //                            if (text.Tag.ToString() == "1") Name = text.Text;
        //                            if (text.Tag.ToString() == "2") ShortDescription = text.Text;
        //                            if (text.Tag.ToString() == "3") Description = text.Text;
        //                            if (text.Tag.ToString() == "4") Appearance = text.Text;
        //                            if (text.Tag.ToString() == "5") Habitat = text.Text;
        //                            if (text.Tag.ToString() == "6") ImagePath = text.Text;
        //                        }
        //                    }
        //                }
        //            }
        //            if (Name != "" && ShortDescription != "" && Description != "" && Appearance != "" && Habitat != "" && ImagePath != "")
        //            {
        //                PageNumber = 1;
        //                await _repositoryAnimal.Add(new Domain.Animal()
        //                {
        //                    Name = Name,
        //                    ShortDescription = ShortDescription,
        //                    Description = Description,
        //                    Appearance = Appearance,
        //                    Habitat = Habitat,
        //                    ImagePath = ImagePath,
        //                    TypeOfAnimalId = TypeOfAnimalId
        //                });
        //                await GetPage(wrapPanel, 0);
        //            }
        //        }
        //    }
        //}
        //#endregion
        //#endregion
        //SecondPage
        //#region
        // private async Task GetSecondPage(WrapPanel wrapPanel)
        // {
        //     wrapPanel.Children.Clear();

        //     var command = new Command() { UserCommand = UserCommandServer.GetTest, Id = _connectService.Id };
        //     _connectService.SendCommand(command);
        //     var res = (await _connectService.ReadCommand()).Test;

        //     //  var res = await _repositoryAnimal.FindByConditionAsync(x => x.TypeOfAnimalId == _typeNumber);

        //     foreach (var item in res)
        //     {
        //         wrapPanel.Children.Add(new Border()
        //         {
        //             Tag = item.Id,
        //             CornerRadius = new System.Windows.CornerRadius(5),
        //             BorderThickness = new Thickness(2),
        //             Margin = new Thickness(10),
        //             Height = 250,
        //             Width = 650,
        //             BorderBrush = Brushes.Black,
        //             Background = (Brush)new BrushConverter().ConvertFrom("#FF4FB7BA"),
        //         });
        //     }

        //     foreach (var item in wrapPanel.Children)
        //     {
        //         if (item is Border border)
        //         {
        //             border.MouseDown += MouseDownBorder;
        //             border.Child = new Grid();
        //             if (border.Child is Grid grid)
        //             {
        //                 grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.75, GridUnitType.Star) });
        //                 grid.ColumnDefinitions.Add(new ColumnDefinition());
        //                 Image image = new Image();
        //                 try
        //                 {
        //                     image.Margin = new Thickness(5);
        //                     image.Stretch = Stretch.UniformToFill;
        //                     image.Source = new BitmapImage(new Uri($"{res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().ImagePath}"));
        //                 }
        //                 catch (Exception) { }
        //                 finally { grid.Children.Add(image); }

        //                 TextBlock textBlock = new TextBlock()
        //                 {
        //                     TextWrapping = TextWrapping.Wrap,

        //                     FontSize = 40,
        //                     HorizontalAlignment = HorizontalAlignment.Stretch,
        //                     VerticalAlignment = VerticalAlignment.Center,
        //                     FontWeight = FontWeights.Bold,
        //                     FontStyle = FontStyles.Italic,
        //                     FontFamily = new FontFamily("Segoe Print"),
        //                     TextAlignment = TextAlignment.Center,
        //                     Text = res.Where(x => x.Id == Convert.ToInt32(border.Tag)).First().Name
        //                 };
        //                 Grid.SetColumn(textBlock, 1);
        //                 grid.Children.Add(textBlock);
        //             }
        //         }
        //     }
        // }
        // #endregion



        #region
        private async Task GetSecondPage(WrapPanel wrapPanel, int number)
        {
            wrapPanel.Children.Clear();

            var command = new Command() { AdminCommand = AdminCommandServer.GetTest, Id = _connectService.Id, Test = new ViewModels.TestViewModel() { Id = number } };
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
                                        Background = Brushes.Transparent,
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

                        //Button butt = new Button();
                        //butt.Tag = border.Tag;
                        //butt.HorizontalAlignment = HorizontalAlignment.Right;
                        //butt.VerticalAlignment = VerticalAlignment.Top;
                        //butt.Background = Brushes.Transparent;
                        //butt.BorderBrush = Brushes.Transparent;
                        //butt.Margin = new Thickness(-5);
                        //butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://image.flaticon.com/icons/png/512/126/126794.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
                        //butt.Click += ButtonClickChangeAnimal;
                        //Grid.SetColumn(butt, 1);
                        //grid.Children.Add(butt);

                        //Button button = new Button()
                        //{
                        //    Content = new Image() { Source = new BitmapImage(new Uri($"https://image.flaticon.com/icons/png/512/61/61848.png")), MaxHeight = 50, Stretch = Stretch.Uniform }
                        //};
                        //button.Click += RemoveButtonClick;
                        //button.Tag = border.Tag;
                        ////button.Width = 100;
                        ////button.Height = 30;
                        //button.Background = Brushes.Transparent;
                        //button.BorderBrush = Brushes.Transparent;
                        //button.HorizontalAlignment = HorizontalAlignment.Right;
                        //button.VerticalAlignment = VerticalAlignment.Top;
                        //button.Margin = new Thickness(-5, -5, 70, -5);
                        //Grid.SetColumn(button, 1);
                        //grid.Children.Add(button);
                    }
                }
            }
        }

        //private async void RemoveButtonClick(object sender, RoutedEventArgs e)
        //{
        //    await _repositoryAnimal.Remove((await _repositoryAnimal.GetAllAsync()).First(x => x.Id == Convert.ToInt32((sender as Button).Tag.ToString())));

        //    PageNumber--;
        //    await GetPage((((sender as Button).Parent as Grid).Parent as Border).Parent as WrapPanel, 0);
        //}

        //private void ButtonClickChangeAnimal(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Button button && button.Parent is Grid grid1)
        //    {
        //        PageNumber++;

        //        foreach (var item in grid1.Children)
        //        {
        //            if (item is TextBox textBox)
        //            {
        //                textBox.IsReadOnly = false;
        //                textBox.Background = Brushes.White;// (Brush)new BrushConverter().ConvertFrom("#FF4FB7BA"),
        //            }
        //            if (item is Button butt)
        //            {
        //                butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Add_document_icon_%28the_Noun_Project_27896%29_blue.svg/1200px-Add_document_icon_%28the_Noun_Project_27896%29_blue.svg.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
        //                butt.Click -= ButtonClickChangeAnimal;
        //                butt.Click += SaveChangeAnimal;
        //            }
        //        }
        //    }
        //}

        //private async void SaveChangeAnimal(object sender, RoutedEventArgs e)
        //{
        //    var Name = "";
        //    var ShortDescription = "";
        //    var Description = "";
        //    var Appearance = "";
        //    var Habitat = "";
        //    //  var ImagePath = "";
        //    int TypeOfAnimalId = _typeNumber;
        //    if (sender is Button button)
        //    {
        //        if (button.Parent is Grid grid)
        //        {
        //            foreach (var item in grid.Children)
        //            {
        //                if (item is TextBox text)
        //                {
        //                    if (text.Tag.ToString() == "1") Name = text.Text;
        //                    if (text.Tag.ToString() == "2") ShortDescription = text.Text;
        //                    if (text.Tag.ToString() == "3") Description = text.Text;
        //                    if (text.Tag.ToString() == "4") Appearance = text.Text;
        //                    if (text.Tag.ToString() == "5") Habitat = text.Text;
        //                    // if (text.Tag.ToString() == "6") ImagePath = text.Text;
        //                }
        //            }
        //            if (Name != "" && ShortDescription != "" && Description != "" && Appearance != "" && Habitat != "" /*&& ImagePath != ""*/)
        //            {
        //                foreach (var item in grid.Children)
        //                {
        //                    if (item is TextBox textBox)
        //                    {
        //                        textBox.IsReadOnly = false;
        //                        textBox.Background = (Brush)new BrushConverter().ConvertFrom("#FF4FB7BA");
        //                    }

        //                    if (item is Button butt)
        //                    {
        //                        butt.Content = new Image() { Source = new BitmapImage(new Uri($"https://image.flaticon.com/icons/png/512/126/126794.png")), MaxHeight = 50, Stretch = Stretch.Uniform };
        //                        butt.Click -= SaveChangeAnimal;
        //                        butt.Click += ButtonClickChangeAnimal;
        //                    }
        //                }

        //                PageNumber = 2;
        //                await _repositoryAnimal.Change(new Domain.Animal()
        //                {
        //                    Id = Convert.ToInt32((grid.Parent as Border).Tag),
        //                    Name = Name,
        //                    ShortDescription = ShortDescription,
        //                    Description = Description,
        //                    Appearance = Appearance,
        //                    Habitat = Habitat

        //                    // ImagePath = ImagePath,
        //                    //TypeOfAnimalId = TypeOfAnimalId
        //                });
        //                await GetPage((grid.Parent as Border).Parent as WrapPanel, 0);
        //            }
        //        }
        //    }
        //}
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