using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Mvvm.Messenger
{
    public class Mediator<TMessage>
    {
        #region Singleton
        private static Mediator<TMessage>? _instance;

        public static Mediator<TMessage> Instance
        {
            get
            {
                return _instance ??= new Mediator<TMessage>();
            }
        }

        private Mediator()
        {
            
        }
        #endregion

        private Action<object, TMessage>? _broadcaster;        

        public void Register(Action<object, TMessage> action)
        {
            _broadcaster += action;
        }

        public void Unregister(Action<object, TMessage> action)
        {
            _broadcaster -= action;
        }

        public void Send(object sender, TMessage message)
        {
            _broadcaster?.Invoke(sender, message);
        }
    }
}
