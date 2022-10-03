import axios from "axios";
import { useEffect } from "react";
import "./App.css";
import { todoURL } from "./endpoints";

function App() {
  console.log(todoURL);
  var todos = 'todos';
  useEffect(() => {
    axios.get("https://localhost:4000/api/Todo").then((response) => {
      console.log(todos);
    });
  }, []);

  return (
    <>
      <h1>My React App</h1>
      <p>Communicated with ASP.NET Core</p>
      {todos}
    </>
  );
}

export default App;
