using Events.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Service
{
    public class DAOFacade
    {
        public EventsDAO EventsDao{ get; }
        private DAOFacade()
        {
            this.EventsDao = new EventsDAO();
        }

        private static DAOFacade _instance;
        public static DAOFacade Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAOFacade();
                }
                return _instance;
            }
        }
    }
}
