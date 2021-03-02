import React, { useState } from "react";
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

    const DB_ERROR_MESSAGE = "Ошибка сервиса БД:"

    const SENT = "sent";
    const DELIVERED = "delivered";
    const ERROR = "error";

    const SmsGorodStatus = {
      [SENT]: 0,
      [DELIVERED]: 1,
      [ERROR]: 2
    };

    // Отправка запроса на создание сообщения
    let allSmsMessages;
    let smsId;
    let status;

    const errorDbSmsMessage = {
      smsId: null,
      senderDate: null,
      phoneNumber,
      senderName,
      messageText: messageStatistics.messageText,
      status: SmsGorodStatus[ERROR],
      statusText: null
    };

    const smsMessage = {
      senderName,
      textContent: messageStatistics.messageText,
      phoneNumber
    };

    try {
      const sentMessageInfos = await SmsGorodService.sendSmsMessage(smsMessage);
      if (sentMessageInfos.data[0].status === ERROR) {
        alert(sentMessageInfos.data[0].errorDescription);
        return;
      }
      status = SmsGorodStatus[ERROR];
      if (sentMessageInfos.data[0].status !== SENT &&
          sentMessageInfos.data[0].status !== DELIVERED) {
        alert(`Неизвестный статус сообщения [${sentMessageInfos.data[0].status}]!`);
        return;
      }

      status = SmsGorodStatus[sentMessageInfos.data[0].status];

      // После запроса получили smsId из сервиса smsgorod
      smsId = sentMessageInfos.data[0].id;
    } catch (error) {

      errorDbSmsMessage.statusText =
        `Ошибка ${error.name}: ${error.message}`;

      try {
        allSmsMessages = await SmsMessagesService
          .createSmsMessage(errorDbSmsMessage);
        props.onSmsSent(allSmsMessages);
      } catch (dbError) {
        alert(`${DB_ERROR_MESSAGE} ${dbError}`);
      }     

      return;
    }

    try {
      // Обратились за последней информацией по созданному сообщению
      const smsInfo = await SmsGorodService.getSmsMessagesInformation([smsId]);
      
      const senderDate = smsInfo.data[0].sentAt !== null 
        ? new Date(smsInfo.data[0].sentAt * 1000) 
        : null;

      const tmpSenderName = smsInfo.data[0].sender;

      // Часть актуальных данных (smsId, status и sendingDate) взяли из smsgorod,
      // остальное из формы заполнения
      const dbSmsMessage = {
        smsId,
        senderDate,
        phoneNumber,
        senderName: tmpSenderName,
        messageText: messageStatistics.messageText,
        status
      };

      try {
        allSmsMessages = await SmsMessagesService
          .createSmsMessage(dbSmsMessage);
      } catch (dbError) {
        alert(`${DB_ERROR_MESSAGE} ${dbError}`);
        return;
      }
    } catch (error) {
      errorDbSmsMessage.smsId = smsId;
      errorDbSmsMessage.statusText =
        `Ошибка ${error.name}: ${error.message}`;
      try {
        allSmsMessages = await SmsMessagesService
          .createSmsMessage(errorDbSmsMessage); 
      } catch (dbError) {
        alert(`${DB_ERROR_MESSAGE} ${dbError}`);
        return;
      }     
    }      
    
    props.onSmsSent(allSmsMessages);    
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