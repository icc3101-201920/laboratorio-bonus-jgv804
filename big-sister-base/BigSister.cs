using System;
using System.Collections.Generic;
using System.Text;

namespace big_sister_base
{
    public class BigSister
    {

        /*public static List<string> recipe = new List<string>(){
            "Láminas de Lasaña",
            "Queso Rallado Parmesano",
            "Carne Molida",
            "Vino Blanco Caja",
            "Tomates Pelados en lata",
            "Bolsa de Zanahorias",
            "Malla de Cebollas",
            "Aceite de Oliva",
            "Sal Lobos",
            "Pimienta",
            "Leche Entera",
            "Harina"
        };*/
        //Evento de LogIn: Se debe publicar cada vez que se realiza un login
        //1- Definir delegate
        public delegate void CheckProductEventHandler(object source, EventArgs args);
        
        public event CheckProductEventHandler ProductCheck;
        public delegate void CheckSLEventHandler(object source, EventArgs args);

        public event CheckSLEventHandler CheckSL;


        //3- Publicar el evento: Se define el metodo OnLoggedIn(). Por convencion es protected y virtual.

        //Evento de RequestChangePassword: Se debe publicar cada vez que se realiza un request para cambiar la contraseña
        //Este lo definiremos sin delegate, usaremos EventHandler<T>
        //1- Definir el evento con EventHandler<>, ademas enviaremos la hora en que se solicitó.
        //1.1- Definiremos una nueva clase llamada RequestEventArgs que tendrá los datos que queremos pasar. Esta hereda de EventArgs
        //1.2- Se define el evento con la clase recien creada y EventHandler
        /*public event EventHandler<RequestEventArgs> ChangePasswordRequested;
        //3- Publicar el evento: Se define el metodo OnChangePasswordRequested()

        //Evento de ChangingPassword: Se debe publicar cada vez que se realiza un intento para cambiar la contraseña
        //Este lo definiremos con delegate ya que necesitamos que retorne bool. Ademas crearemos una clase para ChangingPasswordEventArgs para pasar la contraseña nueva y su confirmación.
        //Esta confirmación la revisará una clase aparte que conoce como verificar (esto es simplemente para mostrar eventos).
        //1- Definir delegate
        public delegate bool ChangingPasswordEventHandler(object source, ChangingPasswordEventArgs args);
        //2- Definir el evento en base al delegate anterior
        public event ChangingPasswordEventHandler ChangingPassword;
        //3- Publicar el evento: Se define el metodo OnChangingPassword()
        */

        public bool CheckP(Product p,LittleGuy pherb)
        {
            //Cada vez que se inicie sesion se debe enviar un mail.
            Console.WriteLine("The Product inserted was: " + p.Name );
            if (pherb.ShopList.Contains(p))
            {
                if (p.Stock == 1)
                {
                  OnProductCheck();
                    return true;
                }
                else
                {
                    Console.WriteLine("The product added is not part of the shopping list");
                    Console.WriteLine("Product was not added");
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("The Product is not part of the store");
                return false;
            }
            
           
        }
        public bool CheckS(List<Product> L, LittleGuy pherb)
        {
            int Counter = 0;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].Stock == 0)
                {
                    Counter += 0;
                }
                else
                {
                    Counter += 1;
                }
            }
            if (Counter == 0)
            {
                OnCheckSL();
                Console.WriteLine("Big sister is satisfied with your selection");
                return true;
            }
            else
            {
                Console.WriteLine("Big sister is not happy with your cart");
                return false;
            }

        }
        protected virtual void OnProductCheck()
        {
            //3.1- Revisar si existen suscriptores
            if (ProductCheck != null)
            {
                //3.2- Se dispara el evento. La fuente es este objeto y EventArgs.Empty ya que no queremos pasar parametros adicionales
                ProductCheck(this, EventArgs.Empty);
            }
        }
        protected virtual void OnCheckSL()
        {
            //3.1- Revisar si existen suscriptores
            if (CheckSL != null)
            {
                //3.2- Se dispara el evento. La fuente es este objeto y EventArgs.Empty ya que no queremos pasar parametros adicionales
                CheckSL(this, EventArgs.Empty);
            }
        }
        /*public void RequestChangePassword()
        {
            //Cada vez que solicite cambio de contraseña debe enviar un mail y sms
            Console.WriteLine("User requesting to change his/her password");
            Console.WriteLine("An email and sms will be send with instructions");
            OnChangePasswordRequested();
        }
        public bool ChangePassword(string newPass, string newPassConf)
        {
            //Se debe verificar en otra clase si los strings son iguales. En dicho caso aceptar el cambio.
            //En caso de que no coincidan se debe imprimir los dos string para que el usuario los vea
            Console.WriteLine("User changing password");
            Console.WriteLine("Checking if passwords match...");
            if (OnChangingPassword(newPass, newPassConf))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void OnLoggedIn()
        {
            //3.1- Revisar si existen suscriptores
            if (LoggedIn != null)
            {
                //3.2- Se dispara el evento. La fuente es este objeto y EventArgs.Empty ya que no queremos pasar parametros adicionales
                LoggedIn(this, EventArgs.Empty);
            }
        }

        protected virtual void OnChangePasswordRequested()
        {
            //3.1- Revisar si existen suscriptores
            if (ChangePasswordRequested != null)
            {
                //3.2- Se dispara el evento. La fuente es este objeto y EventArgs.Empty ya que no queremos pasar parametros adicionales
                ChangePasswordRequested(this, new RequestEventArgs() { RequestDateTime = DateTime.Now });
            }
        }

        protected virtual bool OnChangingPassword(string newPass, string newPassConf)
        {
            bool _success = true;
            //3.1- Revisar si existen suscriptores
            if (ChangingPassword != null)
            {
                //3.2- Se dispara el evento. La fuente es este objeto y EventArgs.Empty ya que no queremos pasar parametros adicionales
                _success = ChangingPassword(this, new ChangingPasswordEventArgs() { NewPass = newPass, NewPassConf = newPassConf });
            }
            return _success;
        }*/
    }

}
