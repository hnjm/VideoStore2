﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Services.Interfaces;
using VideoStore.Business.Components;
using VideoStore.Business.Components.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace VideoStore.Services
{

    class NotifyService : INotifyService
    {
        public IOrderProvider OrderProvider
        {
            get { return ServiceLocator.Current.GetInstance<IOrderProvider>(); }
        }

        public void NotifyOperationOutcome(Guid OrderNumber , DeliveryInfoStatus Status , String Message) {
            Console.WriteLine("result received: Order Id " + 
                        OrderNumber.ToString() + Status.ToString() + "\nmsg: " +Message);
            if (Message == "Success")
            {
                using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer()){
                    Order pOrder = new Order();
                    lContainer.Order
                    PlaceDeliveryForOrder(pOrder);

            }
            else {
                //trying to start delivery
                OrderProvider.SendOrderErrorMessage(OrderNumber, Message);
            }
        }
    }
}
