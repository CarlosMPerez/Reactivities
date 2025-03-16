import axios from "axios";
import { store } from "../stores/store";

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
    await sleep(1000);
    return response;
  } catch (error) {
    console.log(error);
    return Promise.reject(error);
  } finally {
    store.uiStore.setIdle();
  }
});

agent.interceptors.request.use((config) => {
  store.uiStore.setBusy();
  return config;
});

export default agent;
