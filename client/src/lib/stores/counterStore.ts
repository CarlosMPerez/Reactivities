import { makeObservable, observable } from "mobx";

// Example of MobX and MobX-React usage
export default class CounterStore {
  title = "Counter Store";
  count = 0;

  constructor() {
    makeObservable(this, {
      title: observable,
      count: observable,
    });
  }
}
