using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message  {

    public enum Message_T { GOT_INFORMATION, NEED_HEAL };

    Agent sender;
    Agent receiver;
    Message_T message;

    public Message(Agent sender, Agent receiver, Message_T message)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.message = message;
    }

    public void SendMessage()
    {
        receiver.StateMachine.HandleMessage(sender, receiver, message);
    }

    public void SendMessageToMerchant(Merchant merchant)
    {
        receiver.StateMachine.HandleMessage(sender, merchant as Merchant, message);
    }

    public void SendMessageFromMerchant(Merchant merchant)
    {
        receiver.StateMachine.HandleMessage(merchant, receiver, message);
    }

    /*  public void InformMerchant()
      {
          receiver.StateMachine.HandleMerchantInfo(sender, receiver, message);
      }

      public void GetFromMerchant()
      {
          receiver.StateMachine.HandleMessage(sender, receiver, message);
      }*/



}
