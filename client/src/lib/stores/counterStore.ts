import { makeAutoObservable } from "mobx";
//import { action, makeObservable, observable } from "mobx";

// Example of MobX and MobX-React usage
export default class CounterStore {
  title = "Counter Store";
  count = 42;
  events: string[] = [`Initial count is ${this.count}`];

  constructor() {
    // Auto
    makeAutoObservable(this);
    // Manual
    // makeObservable(this, {
    //   title: observable,
    //   count: observable,
    //   increment: action,
    //   decrement: action
    // });
  }

  increment = (amount = 1) => {
    this.count += amount;
    this.events.push(`Incremented by ${amount}. Count is ${this.count}`);
  };

  decrement = (amount = 1) => {
    this.count -= amount;
    this.events.push(`Decremented by ${amount}. Count is ${this.count}`);
  };

  get eventCount() {
    return this.events.length;
  }
}
