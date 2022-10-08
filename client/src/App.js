import axios from "axios";
import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [Data, setData] = useState();
  
  const fetchData = () => {
    axios.get("https://localhost:4000/api/Todo").then((response) => {
      setData(response.data);
    });
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <>
      <h1>My React App</h1>
      <p>Communicated with ASP.NET Core</p>
      <table>
        <thead>
          <tr>
            <td>ID</td>
            <td>USER ID</td>
            <td>TITLE</td>
            <td>DESCRIPTION</td>
          </tr>
        </thead>
        <tbody>
          {Data &&
            Data.map((item, key) => (
              <tr key={key}>
                <td>{item.id}</td>
                <td>{item.userId}</td>
                <td>{item.title}</td>
                <td>{item.description}</td>
              </tr>
            ))}
          <tr></tr>
        </tbody>
      </table>
    </>
  );
}

export default App;
