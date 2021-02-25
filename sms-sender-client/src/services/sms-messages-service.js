const basePath = "https://localhost:44374/api/SmsMessages";

const getSmsMessages = async () => {
  const response = await fetch(basePath);
  const smsMessages = await response.json();
  
  return smsMessages;  
};

const SmsMessagesService = {
  getSmsMessages
};

export default SmsMessagesService;