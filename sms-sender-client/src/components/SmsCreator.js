import React, { useState } from "react";
import { SmsGorodStatus } from "../constants";
import SmsGorodService from "../services/sms-gorod-service";
import SmsMessagesService from "../services/sms-messages-service";

const SmsCreator = (props) => {
  const [messageStatistics, setMessageStatistics] = useState({
    messageLength: 0,
    smsAccount: 0,
    messageText: ""
  });

  const [phoneNumber, setPhoneNumber] = useState("");
  const [senderName, setSenderName] = useState("");

  const handleSmsTextChange = (evt) => {
    const maxSmsLength = 70;

    const text = evt.target.value;

    const intPart = Math.trunc(text.length / maxSmsLength);
    const relPart = text.length % maxSmsLength;
    let smsAccount = intPart;
    if (relPart > 0)
      ++smsAccount;
      
    setMessageStatistics({
      messageLength: text.length,
      smsAccount,
      messageText: text
    })
  };

  const handlePhoneNumberChange = (evt) => {
    setPhoneNumber(evt.target.value);
  };

  const handleSenderNameChange = (evt) => {
    setSenderName(evt.target.value);
  };

  const handleSubmit = async (evt) => {
    evt.preventDefault();

    const SENT = "sent";
    const DELIVERED = "delivered";
    const ERROR = "error";

    const SmsGorodStatus = {
      [SENT]: 0,
      [DELIVERED]: 1,
      [ERROR]: 2
    };

    const smsMessage = {
      senderName,
      textContent: messageStatistics.messageText,
      phoneNumber
    };

    // Отправка запроса на создание сообщения
    const sentMessageInfos = await SmsGorodService.sendSmsMessage(smsMessage);
    if (sentMessageInfos.data.length === 1) {
      let status = SmsGorodStatus[ERROR];
      if (sentMessageInfos.data[0].status === SENT ||
          sentMessageInfos.data[0].status === DELIVERED) {
        status = SmsGorodStatus[sentMessageInfos.data[0].status];            
      }

      const dbSmsMessage = {
        smsId: sentMessageInfos.data[0].id,
        phoneNumber,
        senderName,
        messageText: messageStatistics.messageText,
        status
      };

      const allSmsMessages = await SmsMessagesService
        .createSmsMessage(dbSmsMessage);
      props.onSmsSent(allSmsMessages);
    }
  };

  return (
    <form className="field-list" onSubmit={handleSubmit}>
      <div className="field-item">        
        <label htmlFor="sms-text">Текст:</label>
        <textarea
          className="text-field"
          id="sms-text"
          onChange={handleSmsTextChange}
          value={messageStatistics.messageText}      
          maxLength="350"
          placeholder="от 1 до 350 символов"
          required
        >          
        </textarea>                
        <div className="statistics">{messageStatistics.messageLength} символов; {messageStatistics.smsAccount} sms</div>
      </div>
      
      <div className="field-item">
        <label htmlFor="phone-number">Номер получателя:</label>
        <input 
          type="text"
          id="phone-number"
          pattern="79[0-9]{9}"
          placeholder="79********* пример: 79123456789"
          onChange={handlePhoneNumberChange}
          value={phoneNumber}
          required/>
      </div>

      <div className="field-item">
        <label htmlFor="sender-name">Имя отправителя:</label>
        <input
          type="text"
          id="sender-name"
          onChange={handleSenderNameChange}
          value={senderName}
        />
      </div>     

      <input 
        className="btn btn-send"
        type="submit" 
        value="Отправить" 
      />
    </form>
  );
};

export default SmsCreator;