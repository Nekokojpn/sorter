using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace sorter
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        int[] array;
        int[] karray;
        int comparison = 0;
        int array_access = 0;
        SolidColorBrush green = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        SolidColorBrush red = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        SolidColorBrush blue = new SolidColorBrush(Color.FromRgb(0, 0, 255));
        SolidColorBrush white = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        SolidColorBrush yellow = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        SolidColorBrush lightblue = new SolidColorBrush(Color.FromRgb(66, 0, 183));
        async void initialize()
        {
            array = new int[ARR_SIZE];
            karray = new int[ARR_SIZE];
            Random rd = new Random();
            int temp;
            for (int i = 0; i < ARR_SIZE; i++)
            {
                temp = rd.Next(1, 500);
                //重複排除
                for(int k = 0; k<ARR_SIZE;k++)
                {
                    try
                    {
                        if (karray[k] == temp)
                        {
                            temp = rd.Next(1, 500);
                            k = 0;
                        }
                    }
                    catch(Exception)
                    {
                        ms_er(k.ToString());
                    }
                }
                array[i] = temp;
                karray[i] = array[i];
            }
            int j = 0;
            foreach(Rectangle current in sp.Children)
            { 
                if (current == null)
                {
                    ms_er("Error occurred while initializing canvas height.");
                    Application.Current.Shutdown();
                    return;
                }
                else
                {
                    try
                    {
                        current.Height = array[j];
                        current.Margin = new Thickness(0, 447 - array[j], 0, 0);
                        current.Fill = red;
                        //await delay();
                        current.Fill = white;
                    }
                    catch (Exception) { }
                }
                j++;
            }
        }
        async void initialize_des()
        {
            array = new int[ARR_SIZE];
            karray = new int[ARR_SIZE];
            Random rd = new Random();
            int temp = 500;
            for (int i = 0; i < ARR_SIZE; i++)
            {
                temp -= 2;
                //重複排除
                if (temp != 0)
                {
                    array[i] = temp;
                    karray[i] = array[i];
                }
                else
                {
                    array[i] = 3;
                    karray[i] = array[i];
                }
            }
            
                
            
            int j = 0;
            foreach (Rectangle current in sp.Children)
            {
                if (current == null)
                {
                    ms_er("Error occurred while initializing canvas height.");
                    Application.Current.Shutdown();
                    return;
                }
                else
                {
                    try
                    {
                        current.Height = array[j];
                        current.Margin = new Thickness(0, 447 - array[j], 0, 0);
                        current.Fill = red;
                        await delay();
                        current.Fill = white;
                    }
                    catch (Exception) { }
                }
                j++;
            }
        }
        void ms_er(string tex)
        {
            MessageBox.Show(tex, "sorter", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            initialize();
            //Initialize_audio();
        }

        private void _ref_Click(object sender, RoutedEventArgs e)
        {
            initialize();
        }

        private void _bubble_sort_button_Click(object sender, RoutedEventArgs e)
        {
            Bubble_Sort();
        }


        private void Show_rect_value_Click(object sender, RoutedEventArgs e)
        {
            show_rect_value();
        }

        private void Show_array_value_Click(object sender, RoutedEventArgs e)
        {
            show_array_value();
            
        }

        private void _bubble_sort_button_Copy_Click(object sender, RoutedEventArgs e)
        {
            success();
        }

        private void _merge_sort_button_Click(object sender, RoutedEventArgs e)
        {
            mergesort(ARR_SIZE);
        }

        private void _insertion_sort_button_Click(object sender, RoutedEventArgs e)
        {
            insertionSort();
        }

        private void _show_rect_value_Copy_Click(object sender, RoutedEventArgs e)
        {
            foreach(WMPLib.WindowsMediaPlayer w in media)
            {
                w.controls.play();
            }
            success();
        }

        private void _quick_sort_button_Click(object sender, RoutedEventArgs e)
        {
            quickSortIterative(array, 0, ARR_SIZE-1);
        }

        private void _radix_sort_button_Click(object sender, RoutedEventArgs e)
        {
            radixSort(array, ARR_SIZE, 100);
        }

        private void _heap_sort_button_Click(object sender, RoutedEventArgs e)
        {
            heapSort(array, ARR_SIZE);
        }

        private void _ref_des_Click(object sender, RoutedEventArgs e)
        {
            initialize_des();
        }

        private void arr_size_tex_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                ARR_SIZE = int.Parse(arr_size_tex.Text);
            }
        }

        private void _shaker_sort_button_Click(object sender, RoutedEventArgs e)
        {
            shaker_sort(array, ARR_SIZE);
        }

        private async void _bitonic_sort_button_Click(object sender, RoutedEventArgs e)
        {
            bitonicSort(array, 0, ARR_SIZE, 1);
        }
    }
}
