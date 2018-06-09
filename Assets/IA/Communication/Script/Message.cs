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
        switch (message)
        {
            case Message_T.GOT_INFORMATION:
                //receiver.StateMachine.HandleMessage(message, sender);
                break;
            case Message_T.NEED_HEAL:
                break;
        }
    }



}
