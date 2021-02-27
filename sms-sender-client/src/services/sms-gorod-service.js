import { MethodTypes } from "../constants";

const basePath = "https://new.smsgorod.ru/apiSms";
const apiKey = "4uLqt2XXyyq5t3mnS10BGJVsOgOBMwRWfJkojxqPkhbcSM3V3MCqRykWBGSQ";

const getSmsMessagesInformation = async (smsIds) => {
  const path = `${basePath}/get`;

  const smsIdsObject = {
    "apiKey": apiKey,
    "apiSmsIdList": smsIds
  };

  const options = {
    method: MethodTypes.POST,
    headers: {
      "Content-Type": "application/json",
      "accept": "application/json"
    },
    body: JSON.stringify(smsIdsObject)
  };
  
  const response = await fetch(path, options);

  return await response.json();
};

const sendSmsMessage = async (smsMessage) => {
  const path = `${basePath}/create`;
  const defaultSenderName = "TITAN";

  let senderName = defaultSenderName;
  if (smsMessage.senderName !== "") {
    senderName = smsMessage.senderName;
  }

  const sms = {
    "apiKey": apiKey,
    "sms": [
      {
        "channel": "char",
        "sender": senderName,
        "text": smsMessage.textContent,
        "phone": smsMessage.phoneNumber
      }
    ]
  };

  const options = {
    method: MethodTypes.POST,
    headers: {
      "Content-Type": "application/json",
      "accept": "application/json"
    },
    body: JSON.stringify(sms)
  };

  const response = await fetch(path, options);

  return await response.json();
};

const SmsGorodService = {
  getSmsMessagesInformation,
  sendSmsMessage
};

export default SmsGorodService;