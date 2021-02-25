import { MethodTypes } from "../constants";

const basePath = "https://new.smsgorod.ru/apiSms";
const apiKey = "4uLqt2XXyyq5t3mnS10BGJVsOgOBMwRWfJkojxqPkhbcSM3V3MCqRykWBGSQ";

const getSmsMessagesInformation = async (smsIds) => {
  const path = `${basePath}/get`;

  const smsIdsObject = {
    "apiKey": apiKey,
    "apiSmsIdList": smsIds
  }

  const options = {
    method: MethodTypes.POST,
    headers: {
      "Content-Type": "application/json",
      "accept": "application/json"
    },
    body: JSON.stringify(smsIdsObject)
  }
  
  const response = await fetch(path, options);

  return await response.json();
};

const SmsGorodService = {
  getSmsMessagesInformation
};

export default SmsGorodService;