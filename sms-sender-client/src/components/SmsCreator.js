import React, { useEffect, useState } from "react";
import SmsMessagesService from "../services/sms-messages-service";

const SmsCreator = () => {
  const [messageStatistics, setMessageStatistics] = useState({
    messageLength: 0,
    smsAccount: 0
  });

  useEffect(() => {
    const getSmsMessages = async () => {
      const smsMessages = await SmsMessagesService.getSmsMessages();
      const smsIds = smsMessages.map((smsMessage) => smsMessage.smsId);
      console.log(smsIds);
    }

    getSmsMessages();
  });

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
      smsAccount
    })
  };

  return (
    <form className="field-list">
      <div className="field-item">        
        <label for="sms-text">Текст:</label>
        <textarea
          className="text-field"
          id="sms-text"
          onChange={handleSmsTextChange}
          maxLength="350"
          required
        >          
        </textarea>                
        <div className="statistics">{messageStatistics.messageLength} символов; {messageStatistics.smsAccount} sms</div>
      </div>
      
      <div className="field-item">
        <label for="phone-number">Номер получателя:</label>
        <input type="tel" id="phone-number" required/>
      </div>

      <div className="field-item">
        <label for="sender-name">Имя отправителя:</label>
        <input type="text" id="sender-name"/>
      </div>

      <button className="btn btn-send">Отправить</button>      
    </form>
  );
};

export default SmsCreator;