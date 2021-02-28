import { MethodTypes } from "../constants";

const basePath = "https://localhost:44374/api/SmsMessages";

const getSmsMessages = async () => {
  const response = await fetch(basePath);
  const smsMessages = await response.json();
  
  return smsMessages;  
};

const updateSmsMessages = async (smsMessages) => {
  const options = {
    method: MethodTypes.PUT,
    headers: {
      "Content-Type": "application/json",
      "accept": "application/json"      
    },
    body: JSON.stringify(smsMessages)
  };

  const response = await fetch(basePath, options);

  return await response.json();
};

const createSmsMessage = async (smsMessage) => {
  const options = {
    method: MethodTypes.POST,
    headers: {
      "Content-Type": "application/json",
      "accept": "application/json"      
    },
    body: JSON.stringify(smsMessage)
  };

  const response = await fetch(basePath, options);

  return await response.json();
}

const SmsMessagesService = {
  getSmsMessages,
  updateSmsMessages,
  createSmsMessage
};

export default SmsMessagesService;