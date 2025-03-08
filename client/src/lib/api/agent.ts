import axios from "axios";

const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

const agent = axios.create({
  // From .env.development
  baseURL: import.meta.env.VITE_API_URL,
});

// Let's use interceptors to introduce a fake delay in the app
agent.interceptors.response.use(async (response) => {
  try {
    await sleep(500);
    return response;
  } catch (error) {
    console.log(error);
    return Promise.reject(error);
  }
});

export default agent;
