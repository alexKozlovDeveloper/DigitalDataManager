using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ddm.Db.Repositoryes;
using Ddm.Db.TableEntityes;
using Ddm.Helpers.Mail;

namespace DdmService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public ActivateCode CreateUserWithActivateCode(string login, string password, string email)
        {
            var rep = new DdmRepository();

            var user = rep.CreateUser(login, password, email);
            var activateCode = rep.CreateActivateCode(user.Id);

            var mh = new MailHelper("smtp.gmail.com", "imagebox.ddm@gmail.com", "imageboxddm2015");
            var mes = new MailEntity("Activate Code", "Hello " + user.Login + ", your activate code is " + activateCode.Code, email);
            mh.SendMail(mes);

            return activateCode;
        }
    }
}
