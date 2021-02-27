import React, { useEffect, useState } from "react";
import './App.css';
import SmsCreator from './components/SmsCreator';
import SmsMessagesService from "./services/sms-messages-service";
import SmsGorodService from "./services/sms-gorod-service";
import { SmsStatus } from "./constants";
import moment from "moment";

function App() {
  const [smsMessages, setSmsMessages] = useState([]);
  
  useEffect(() => {
    const getSmsMessages = async () => {
      // Получение информации о сохраненных смс в БД
      const smsMessages = await SmsMessagesService.getSmsMessages();
      console.log(smsMessages);

      // Получение информации об смс-сообщениях от smsgorod
      const smsIds = smsMessages.map((smsMessage) => smsMessage.smsId);      
      const smsMessagesInfoObject = await SmsGorodService
        .getSmsMessagesInformation(smsIds);
      console.log(smsMessagesInfoObject);

      const paramSmsMessages = [];

      // Цикл по всем сообщениям, сохраненным в БД
      smsMessages.forEach((smsMessage) => {
        const tmpSmsMessage = smsMessagesInfoObject.data
          .find((smsMessage1) => smsMessage1.id === smsMessage.smsId);
        if (tmpSmsMessage !== undefined) {
          paramSmsMessages.push({
            id: smsMessage.id,            
            sendingDate: new Date(tmpSmsMessage.sentAt * 1000),
            status: smsMessage.status
          });
        }
      });

      const allSmsMessages = await SmsMessagesService
        .updateSmsMessage(paramSmsMessages);
      setSmsMessages(allSmsMessages);
    };

    getSmsMessages();
  }, []);

  return (
    <div className="App">
      <div className="wrapper">
        <h1>Отправка сообщений</h1>
        <div className="full-container">
          <section className="sms-form-container">
            <h2 className="visually-hidden">Форма отправки сообщения</h2>
            <SmsCreator/>
          </section>
          <section className="sms-list-container">
            <h2 className="visually-hidden">Список отправленных сообщений</h2>
            <table className="sms-list">
              <thead>
                <tr>
                  <th className="cell-item">Дата и время отправки</th>
                  <th className="cell-item">Номер получателя</th>
                  <th className="cell-item">Текст сообщения</th>
                  <th className="cell-item">Статус сообщения</th>
                </tr>
              </thead>
              <tbody>
                {smsMessages.map((smsMessage) => {
                  return (
                    <tr key={smsMessage.id}>
                      <td className="cell-item">{moment(smsMessage.sendingDate).format("DD.MM.YYYY hh:mm")}</td>
                      <td className="cell-item">{smsMessage.phoneNumber}</td>
                      <td className="text-cell-item">{smsMessage.messageText}</td>
                      <td className="cell-item">{SmsStatus[smsMessage.status]}</td>
                    </tr>
                  );                
                })}
              </tbody>              
            </table>
          </section>
        </div>
        
      </div>
    </div>
  );
}

export default App;
