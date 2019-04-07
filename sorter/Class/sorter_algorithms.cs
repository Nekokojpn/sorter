using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using WMPLib;
namespace sorter
{
    public partial class MainWindow : Window
    {
        int ARR_SIZE = 200;
        //Load audio
        WMPLib.WindowsMediaPlayer[] media = new WindowsMediaPlayer[50];
        async void Initialize_audio()
        {
            for(int i = 0; i<50;i++)
            {
                media[i] = new WindowsMediaPlayer();
                media[i].settings.autoStart = false;

                media[i].URL = System.IO.Path.GetDirectoryName(Application.ResourceAssembly.Location.ToString())+@"\aud\"+(i+1).ToString()+".mp3";
                media[i].settings.volume = 100;
                media[i].controls.play();
               // await Task.Delay(10);
            }
        }


        debugClass d = new debugClass();
        int add_comparison()
        {
            comparison++;
            comp_tex.Content = comparison.ToString();
            return 0;
        }
        int add_array_access()
        {
            array_access++;
            access_tex.Content = array_access.ToString();
            return 0;
        }
        async Task<int> delay()
        {
            try
            {
                await Task.Delay(int.Parse(delay_tex.Text));
                return 0;
            }
            catch(Exception)
            {
                await Task.Delay(10);
                return 0;
            }
        }
        int Search_Rectangle(int searchnum)
        {
            int cindex = 0;
            foreach (Rectangle rr in sp.Children)
            {
                if (searchnum == rr.Height)//&&indexをつけて重複にも対処
                {
                    ms_er("cindex:" + cindex.ToString() + "rr.h:" + rr.Height.ToString());
                    break;
                }
                cindex++;
            }
            return 0;
        }
        async void AddtoSp(int index,Rectangle element)
        {
            int cindex = 0;
            Rectangle rect;
            foreach (Rectangle r in sp.Children)
            {
                if(index==cindex)
                {
                    sp.Children.Add(element);
                    mark_blue(element);
                    await Task.Delay(10);
                    element.Fill = white;
                    break;
                }
                cindex++;
            }
        }
        void play_sound(int num)
        {
           // media[num].controls.stop();
           // media[num].controls.play();
        }
        async void mark_red(Rectangle rec)
        {
            rec.Fill = red;
            play_sound((int)rec.Height / 10);
            await Task.Delay(10);
            rec.Fill = white;
        }
        async void mark_green(Rectangle rec)
        {
            rec.Fill = green;
            play_sound((int)rec.Height / 10);
            await Task.Delay(10);
            rec.Fill = white;
        }
        async void mark_blue(Rectangle rec)
        {
            rec.Fill = blue;
            play_sound((int)rec.Height / 10);
            await Task.Delay(30);
            rec.Fill = white;
        }
        async void mark_yellow(Rectangle rec)
        {
            rec.Fill = yellow;
            play_sound((int)rec.Height / 10);
            await Task.Delay(30);
            rec.Fill = white;
        }
        Rectangle FindNameRect(int searchnum,int index)
        {
            Rectangle r = null;
            int cindex = 0;
            foreach(Rectangle rr in sp.Children)
            {
                if(searchnum == rr.Height&&cindex ==index)//&&indexをつけて重複にも対処
                {
                    r = rr;
                    break;
                }
                cindex++;
            }
            return r;
        }
        Rectangle FindNameRect_from_value(int searchnum)
        {
            Rectangle r = null;
            foreach (Rectangle rr in sp.Children)
            {
                if (searchnum == rr.Height)
                {
                    r = rr;
                    break;
                }
            }
            return r;
        }
        Rectangle FindNameRect_nolonger(int index)
        {
            Rectangle r = null;
            int cindex = 0;
            foreach (Rectangle rr in sp.Children)
            {
                if (cindex == index)
                {
                    r = rr;
                    break;
                }
                cindex++;
            }
            return r;
        }

        void RegisterRect(int num, Rectangle rect)
        {
            UnregisterName("r" + (num).ToString());
            RegisterName("r" + (num).ToString(), rect);
        }
        void show_array_value()
        {
            string te = "";
            foreach (int k in array)
            {
                te += " " + k.ToString();
            }
            d.a_method(te);
            arrays ar = new arrays();
           // ar..Text = te;
            ar.Show();
        }
        void show_rect_value()
        {
            string te = "";
            foreach(Rectangle r in sp.Children)
            {
                te += " " + r.Height.ToString();
            }
            d.a_method(te);
            arrays ar = new arrays();
            ar.tex.Text = te;
            ar.Show();
        }
        int sort_initialize()
        {
            comp_tex.Content = "0";
            access_tex.Content = "0";
            Rectangle rect;
            foreach (Rectangle r in sp.Children)
            {
                r.Fill = white;
            }
            return 0;
        }

        void show_name()
        {
            string st = "";
            Rectangle rect;
            foreach (Rectangle r in sp.Children)
            {
                st += " " + r.Name;
            }
            ms_er(st);
        }
        async void success()
        {
            d.a_event("SORT SUCCESS!!");
            int ind = 0;
            Rectangle rect;
            foreach (Rectangle r in sp.Children)
            {
                if (ind==ARR_SIZE)
                {
                    break;
                }
                r.Fill = red;
                play_sound((int)r.Height / 10);
                await Task.Delay(1);
                r.Fill = green;
                
                ind++;
            }
        }
 
        /*
     　　 バブルソートはリストにおいて隣り合うふたつの要素の値を比較して条件に応じた交換を行う整列アルゴリズムです。

　　　条件とは値の大小関係です。「値の大きい順(降順)」か「値の小さい順(昇順)」にリストを並び替えます。

　　　このソートを実行すると値の大きいまたは小さい要素が浮かびあがってくるように見えることから、バブル(bubble: 泡)ソートと呼ばれます。
         */
        async void Bubble_Sort()
        {
            sort_initialize();
            int i, j;
            for (i = 0; i < (ARR_SIZE - 1); i++)
            {
                for (j = (ARR_SIZE - 1); j > i; j--)
                {
                    add_array_access();
                    add_array_access();
                    add_comparison();
          
                    if (array[j - 1] > array[j])
                    {

                       // temp = array[j - 1];
                        add_array_access();
                        //array[j - 1] = array[j];
                        add_array_access();
                        add_array_access();
                        await swap(array, j, j - 1);                   
                        //array[j] = temp;
                        add_array_access();
                    }               
                }
            }
            success();
        }
        /*
         挿入ソートは整列されている部分が多ければ多いほど計算量が減り、処理速度は向上します。
        反対に、「昇順に整列されたものを降順に並び替える」というように、
        逆順のリストを対象とした場合にもっとも遅くなります。
         

    */
        async void insertionSort()
        {
            sort_initialize();
            int i, j,tmp;
            Rectangle current=null,current2,greencurrent=null;
            greencurrent = FindNameRect(array[0],0);
            mark_green(greencurrent);
            for (i=1;i<ARR_SIZE;i++)
            {
                j = i;

                add_array_access();
                add_array_access();
                add_comparison();
               
               

                

                while ((j>0)&&(array[j-1]>array[j]))
                {
                    current = FindNameRect(array[j - 1], j - 1);
                current2 = FindNameRect(array[j], j);
                    mark_red(current);
                    mark_red(current2);

                    add_array_access();
                    tmp = array[j - 1];

                    

                    add_array_access();
                    add_array_access();
                    array[j - 1] = array[j];
                    sp.Children.Remove(current);
                    sp.Children.Remove(current2);

                    sp.Children.Insert(j - 1, current);
                    sp.Children.Insert(j - 1, current2);


                    array[j] = tmp;
                    add_array_access();


                    await delay();
                    j--;
                    add_comparison();
                    add_array_access();
                    add_array_access();
                }
                try
                {
                    greencurrent.Fill = white;
                    greencurrent = current;
                    greencurrent.Fill = green;
                    await delay();
                    await delay();
                    await delay();
                    greencurrent.Fill = green;
                }
                catch (Exception) { }
            }
            success();
        }


        /*マージソートは整列されていないリストを2つのリストに分割して、それぞれを整列させた後、それらをマージして整列済みのひとつのリストを作ります。

         マージを利用してリストを整列するのでマージソートという名がついています。
         ->non recursive*/
        //同じサイズのバッファが必要.
        int[] buf;
        async void mergesort(int num)
        {
            sort_initialize();
            buf = new int[ARR_SIZE];
            sort_initialize();
            Rectangle current;
            int rght, rend;
            int i, j, m;

            for (int k = 1; k < num; k *= 2)
            {
                for (int left = 0; left + k < num; left += k * 2)
                {
                    rght = left + k;
                    rend = rght + k;
                    if (rend > num)
                    {
                        rend = num;
                    }

                    m = left;
                    i = left;
                    j = rght;

                    while (i < rght && j < rend)
                    {
                        add_array_access();
                        add_array_access();
                        add_comparison();
                        if (array[i] <= array[j])
                        {
                            current = FindNameRect_nolonger(i);
                            mark_red(current);
                            add_array_access();
                            buf[m] = array[i]; i++;
                            await Task.Delay(10);
                        }
                        else
                        {
                            current = FindNameRect_nolonger(j);
                            mark_red(current);
                            add_array_access();
                            buf[m] = array[j]; j++;
                            await Task.Delay(10);
                        }
                        m++;
                    }
                    while (i < rght)
                    {
                        current = FindNameRect_nolonger(i);
                        mark_red(current);
                        add_array_access();
                        buf[m] = array[i];
                        await Task.Delay(10);
                        i++; m++;
                    }
                    while (j < rend)
                    {
                        current = FindNameRect_nolonger(j);
                        mark_red(current);
                        add_array_access();
                        buf[m] = array[j];
                        await Task.Delay(10);
                        j++; m++;
                    }
                    for (m = left; m < rend; m++)
                    {
                        current = FindNameRect_nolonger(m);
                        mark_blue(current);
                        add_array_access();
                        array[m] = buf[m];
                        current.Height = buf[m];
                        current.Margin = new Thickness(0, 447 - buf[m], 0, 0);
                        await Task.Delay(10);
                    }
                }
            }
            success();
        }
        /*
         クイックソートではピボットと呼ぶ軸となる要素の値より大きい要素群、
         小さい要素群という具合にソートの対象となる部分を小さくしてゆきながら全体のソートを完了させます。
         */
        async Task<int> swap(int[] arr,int from, int to)
        {
            Rectangle current, current2;

            add_array_access();
            int temp = arr[from];

            current = FindNameRect_nolonger(from);
            current2 = FindNameRect_nolonger(to);
            current.Height = current2.Height;
            current.Margin = new Thickness(0, 447 - current2.Height, 0, 0);
            current2.Height = arr[from];
            current2.Margin = new Thickness(0, 447 - arr[from], 0, 0);
            mark_red(current);
            mark_red(current2);
            await Task.Delay(10);

            add_array_access();
            add_array_access();
            arr[from] = arr[to];

            add_array_access();
            arr[to] = temp;

            return 0;
        }
        /* This function is same in both iterative and recursive*/
        async Task<int> partition(int[] arr, int l, int h)
        {
            Rectangle current, current2;
            current = FindNameRect_nolonger(l);
            current2 = FindNameRect_nolonger(h);
            mark_yellow(current);
            mark_yellow(current2);

            add_array_access();

            int x = arr[h];
            int i = (l - 1);

            for (int j = l; j <= h - 1; j++)
            {
                add_array_access();
                add_comparison();
                if (arr[j] <= x)
                {
                    i++;
                    await Task.Delay(10);
                    await swap(arr,i, j);
                }
            }
            await Task.Delay(10);
            await swap(arr,i + 1, h);
            return (i + 1);
        }

        /* A[] --> Array to be sorted,  
           l  --> Starting index,  
           h  --> Ending index */
        async void quickSortIterative(int[] arr, int l, int h)
        {
            sort_initialize();
            // Create an auxiliary stack 
            int[] stack = new int[h - l + 1];

            // initialize top of stack 
            int top = -1;

            // push initial values of l and h to stack 
            stack[++top] = l;
            stack[++top] = h;

            // Keep popping from stack while is not empty 
            while (top >= 0)
            {
                // Pop h and l 
                h = stack[top--];
                l = stack[top--];

                // Set pivot element at its correct position 
                // in sorted array 
                await Task.Delay(10);
                int p = await partition(arr, l, h);

                // If there are elements on left side of pivot, 
                // then push left side to stack 
                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                // If there are elements on right side of pivot, 
                // then push right side to stack 
                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
            }
            success();
        }

        async Task<int> swap_blue(int[] arr, int from, int to)
        {
            Rectangle current, current2;

            add_array_access();
            int temp = arr[from];

            current = FindNameRect_nolonger(from);
            current2 = FindNameRect_nolonger(to);
            current.Height = current2.Height;
            current.Margin = new Thickness(0, 447 - current2.Height, 0, 0);
            current2.Height = arr[from];
            current2.Margin = new Thickness(0, 447 - arr[from], 0, 0);
            mark_blue(current);
            mark_blue(current2);
            await Task.Delay(10);

            add_array_access();
            add_array_access();
            arr[from] = arr[to];

            add_array_access();
            arr[to] = temp;

            return 0;
        }
        async void radixSort(int[] arr,int n,int r)//arr=データ配列, n=データ数, r=最大基数
        {
            //ソート前の初期化
            sort_initialize();

            //必要一時領域
            int[] rad = new int[n];
            int[] work = new int[n];
            //System.Windows.Controls
            Rectangle current;

            int i, j, k;
            int m = 1;

            while(m<=r)
            {
                for(i=0;i<n;i++)
                {
                    add_array_access();//配列へのアクセス回数をカウント
                    current = FindNameRect_nolonger(i);//arr[i]の可視化している四角コントロールを取得するメソッド:戻り値Rectangle
                    mark_red(current);//取得した四角を赤くするメソッド:戻り値なし
                    rad[i] = (arr[i] / m) % 10;
                    await delay();//待機する
                }
                k = 0;
                for(i=0;i<=9;i++)
                {
                    for(j=0;j<n;j++)
                    {
                        if(rad[j]==i)
                        {
                            add_array_access();
                            current = FindNameRect_nolonger(j);
                            mark_red(current);
                            work[k++] = arr[j];
                            await delay();
                        }
                    }
                }
                for(i=0;i<n;i++)
                {
                    add_array_access();
                    current = FindNameRect_nolonger(i);

                    current.Height = work[i];
                    current.Margin = new Thickness(0, 447 - work[i], 0, 0);
                    mark_blue(current);

                    arr[i] = work[i];
                    await delay();
                }
                m *= 10;
            }
            success();//成功メソッド
        }

        async void buildMaxHeap(int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                // if child is bigger than parent 
                if (arr[i] > arr[(i - 1) / 2])
                {
                    int j = i;

                    // swap child and parent until 
                    // parent is smaller 
                    while (arr[j] > arr[(j - 1) / 2])
                    {
                        try
                        {
                            swap(arr, arr[j], arr[(j - 1) / 2]);
                            j = (j - 1) / 2;
                        }
                        catch(Exception)
                        {
                            ms_er(j.ToString());
                        }
                    }
                }
            }
        }

        async void heapSort(int[] arr, int n)
        {
            buildMaxHeap(arr, n);

            for (int i = n - 1; i > 0; i--)
            {
                // swap value of first indexed  
                // with last indexed  
                swap(arr,arr[0], arr[i]);

                // maintaining heap property 
                // after each swapping 
                int j = 0, index;

                do
                {
                    index = (2 * j + 1);

                    // if left child is smaller than  
                    // right child point index variable  
                    // to right child 
                    if (arr[index] < arr[index + 1] &&
                                        index < (i - 1))
                        index++;

                    // if parent is smaller than child  
                    // then swapping parent with child  
                    // having higher value 
                    if (arr[j] < arr[index] && index < i)
                         swap(arr,arr[j], arr[index]);

                    j = index;
                    await delay();
                } while (index < i);
            }
        }
        async void shaker_sort(int[] a, int N)
        {
            Rectangle current, current2;
            int left, right, i, shift=0, t;

            left = 0; right = N - 1;     /* leftとrightを初期化 */
            while (left < right)
            {    /* left<rightの間繰り返す */
                for (i = left; i < right; i++)
                {  /* 左からのバブル・ソート */
                    add_array_access();
                    add_array_access();
                    add_comparison();
                    if (a[i] > a[i + 1])
                    {
                        await swap_blue(a, i, i + 1);

                    
                        shift = i;               /* 交換した位置をshiftに */
                    }
                    await Task.Delay(10);
                }
                right = shift;               /* 最後に交換した位置shiftをrightに */
                for (i = right; i > left; i--)
                {  /* 右からのバブル・ソート */
                    add_array_access();
                    add_array_access();
                    add_comparison();
                    if (a[i] < a[i - 1])
                    {
                        await swap_blue(a, i, i - 1);
                       
                        shift = i;               /* 交換した位置をshiftに */
                    }
                    await Task.Delay(10);
                }
                left = shift;               /* 最後に交換した位置shiftをleftに */
                await Task.Delay(10);
            }
        }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public static void compAndSwap(int[] a, int i, int j, int dir)
        {
            int k;
            if ((a[i] > a[j]))
                k = 1;
            else
                k = 0;
            if (dir == k)
                Swap(ref a[i], ref a[j]);
        }

        /*It recursively sorts a bitonic sequence in ascending order,  
          if dir = 1, and in descending order otherwise (means dir=0).  
          The sequence to be sorted starts at index position low,  
          the parameter cnt is the number of elements to be sorted.*/
        public static void bitonicMerge(int[] a, int low, int cnt, int dir)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;
                for (int i = low; i < low + k; i++)
                    compAndSwap(a, i, i + k, dir);
                bitonicMerge(a, low, k, dir);
                bitonicMerge(a, low + k, k, dir);
            }
        }

        /* This function first produces a bitonic sequence by recursively  
            sorting its two halves in opposite sorting orders, and then  
            calls bitonicMerge to make them in the same order */
        public static void bitonicSort(int[] a, int low, int cnt, int dir)
        {
            if (cnt > 1)
            {
                int k = cnt / 2;

                // sort in ascending order since dir here is 1  
                bitonicSort(a, low, k, 1);

                // sort in descending order since dir here is 0  
                bitonicSort(a, low + k, k, 0);

                // Will merge wole sequence in ascending order  
                // since dir=1.  
                bitonicMerge(a, low, cnt, dir);
            }
        }

        /* Caller of bitonicSort for sorting the entire array of  
           length N in ASCENDING order */
        public static void sort(int[] a, int N, int up)
        {
            bitonicSort(a, 0, N, up);
        }
    }
}
