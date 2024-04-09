using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        string s = "";
        int a = 0;
        string strA = "";
        bool boolA = false;//пустое, готово к записи        
        int b = 0;
        string strB = "";
        bool boolB = false;//пустое, готово к записи  
        string strOperation = "";
        string outputString = "";
        string operationArifmetical = "";
        bool isRadian = false;
        Encoding asciiEncoding = Encoding.ASCII;
        string strEncoding = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var s = (Button)(e.Source);
                // MessageBox.Show(s.Content.ToString());
                Char sChar = '\0';

                if (s.Content.ToString().Length == 1)
                {
                    sChar = Convert.ToChar(s.Content);
                }
                if (s.Content.ToString().Length > 1)
                {
                    strOperation = s.Content.ToString();
                }


                if (strOperation.Equals("del"))
                {
                    boolA = false;
                    boolB = false;
                    output.Text = "";
                    strA = "";
                    strB = "";
                    strOperation = "";
                    operationArifmetical = "";
                }

                // &#8730;

                else if (s.Content.ToString() == "√")
                {
                    double res = Math.Round(Math.Sqrt(Convert.ToDouble(strA)), 10);
                    output.Text = res.ToString();
                    strA = res.ToString();
                    strB = "";
                    operationArifmetical = "";
                    strOperation = "";
                }

                else if ((strA != "") && (strB == "") && (strOperation == "sin" || strOperation == "cos" || strOperation == "tan" || strOperation == "cot" || strOperation.Equals("1/x")))
                {
                    boolA = false;
                    boolB = false;
                    double res = 0.0;
                    switch (strOperation)
                    {
                        case "sin":
                            {
                                if (isRadian) res = Math.Round(Math.Sin(Convert.ToDouble(strA)), 2);
                                else
                                {
                                    var radians = Math.PI * Convert.ToDouble(strA) / 180.0;
                                    res = Math.Round(Math.Sin(radians), 2);
                                }
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "cos":
                            {
                                if (isRadian) res = Math.Round(Math.Cos(Convert.ToDouble(strA)), 2);
                                else
                                {
                                    var radians = Math.PI * Convert.ToDouble(strA) / 180.0;
                                    res = Math.Round(Math.Cos(radians), 2);
                                }
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "tan":
                            {
                                if (isRadian) res = Math.Round(Math.Tan(Convert.ToDouble(strA)), 2);
                                else
                                {
                                    var radians = Math.PI * Convert.ToDouble(strA) / 180.0;
                                    res = Math.Round(Math.Tan(radians), 2);
                                }
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "cot":
                            {
                                if (isRadian) res = 1 / (Math.Round(Math.Tan(Convert.ToDouble(strA)), 2));
                                else
                                {
                                    var radians = Math.PI * Convert.ToDouble(strA) / 180.0;
                                    res = 1 / (Math.Round(Math.Tan(radians), 2));
                                }
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }

                        case "1/x":
                            {
                                res = Math.Round((1 / (Convert.ToDouble(strA))), 10);
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }


                    }
                }
                else if ((strA != "") && (strB != "") && (strOperation.Equals("x^n")) && operationArifmetical == "=")
                {
                    double res = Math.Pow(Convert.ToInt32(strA), Convert.ToInt32(strB));
                    output.Text = res.ToString();
                    strA = res.ToString();
                    strB = "";
                    operationArifmetical = "";
                    strOperation = "";
                }

                else if ((sChar == '=' || sChar == '+' || sChar == '-' || sChar == '*' || sChar == '/') && (strA != "") && (strB != "") && (operationArifmetical != ""))
                {
                    boolA = false;
                    boolB = false;
                    double res = 0.0;
                    switch (operationArifmetical)
                    {
                        case "+":
                            {
                                res = Convert.ToDouble(strA) + Convert.ToDouble(strB);
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "-":
                            {
                                res = Convert.ToDouble(strA) - Convert.ToDouble(strB);
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "*":
                            {
                                res = Convert.ToDouble(strA) * Convert.ToDouble(strB);
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                        case "/":
                            {
                                res = Convert.ToDouble(strA) / Convert.ToDouble(strB);
                                output.Text = res.ToString();
                                strA = res.ToString();
                                strB = "";
                                operationArifmetical = "";
                                strOperation = "";
                                break;
                            }
                    }
                }


                else if (Char.IsDigit(sChar))
                {
                    if ((!boolA) && (operationArifmetical == ""))// первое число готово к записи, операция не определена
                    {
                        strA += sChar;
                    }
                    else if ((boolA) && (!boolB)) // второе число готово к записи, операция не определена
                    {
                        strB += sChar;
                    }
                    output.Text += sChar;
                }

                else if ((strA != "") && (strB == "") && (strOperation.Equals("x^n")))
                {
                    boolA = true;
                    output.Text = "";
                    operationArifmetical = "=";
                }



                else if ((sChar == '+' || sChar == '-' || sChar == '*' || sChar == '/') && (strA != "") && (strB == ""))
                {
                    boolA = true;
                    operationArifmetical = sChar.ToString();
                    output.Text = "";
                }


            }




            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var b = (Button)(e.Source);
            if (isRadian == false)
            {
                b.Content = "Radian".ToString();
                isRadian = true;
                buttonGradusRadian.Background = new SolidColorBrush(Color.FromRgb(1, 233, 13));

            }
            else
            {
                b.Content = "Gradus".ToString();
                isRadian = false;
                buttonGradusRadian.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            }
        }
    }
}