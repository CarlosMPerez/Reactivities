import "./App.css";
import { useEffect, useState } from "react";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/activities")
      .then((response) => response.json())
      .then((data) => setActivities(data));
  }, []);

  return (
    <>
      <h3 className="app" style={{ color: "red" }}>
        Reactivities
      </h3>
      <ul>
        {activities.map((actv) => (
          <li key={actv.id}>{actv.title}</li>
        ))}
      </ul>
    </>
  );
}

export default App;
