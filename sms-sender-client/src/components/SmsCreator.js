import React, { useState } from "react";

const SmsCreator = () => {
  const [messageStatistics, setMessageStatistics] = useState({
    messageLength: 0,
    smsAccount: 0
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
        <label htmlFor="sms-text">Текст:</label>
        <textarea
          className="text-field"
          id="sms-text"
          onChange={handleSmsTextChange}
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
          required/>
      </div>

      <div className="field-item">
        <label htmlFor="sender-name">Имя отправителя:</label>
        <input type="text" id="sender-name"/>
      </div>

      <button className="btn btn-send">Отправить</button>      
    </form>
  );
};

export default SmsCreator;