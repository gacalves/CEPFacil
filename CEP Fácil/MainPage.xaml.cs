using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CEP_Fácil
{

    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, JsonHelper.ICalbackInterface
    {
        private static string baseUrl = "http://api.postmon.com.br/v1/cep/{0}";

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
           JsonHelper.GetJsonString(String.Format(baseUrl, txtCep.Text),this);
           
           txtResultado.Text = "Processando...";
        }

        public void GetJsonStringCallback(string json)
        {
            var obj = JsonHelper.GetObjectFromJsonString<RootObject>(json);
            if (String.IsNullOrEmpty(obj.cep))
            {
                txtResultado.Text = "CEP Inválido!\nVerifique o CEP digitado e tente novamente.";
                return;
            }
            string resultado = "Rua: {0}\n Bairro: {1} \n Cidade: {2} \n Estado: {3}";
            resultado = String.Format(resultado, obj.logradouro, obj.bairro, obj.cidade, obj.estado);
            
            txtResultado.Text = resultado;
        }
    }
}
