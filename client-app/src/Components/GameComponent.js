
import axios from "axios";
import { useEffect, useState } from "react";
 
function GameComponent() {
const [games, setGame] = useState([]);
const [gameId, setgameId] = useState("");
const [sportId, setsportId] = useState("");
const [start, setStart] = useState("");
const [courtId, setCourtId] = useState("");
const [PredictedEnd, setPredictedEnd] = useState("");
  useEffect(() => {
    (async () => await Load())();
  }, []);
  async function Load() {
    const result = await axios.get("https://localhost:7124/GetAllGames");
    setGame(result.data);
    console.log(result.data);
    console.log(gameId)
  }
  // async function save(event) {
  
  //   event.preventDefault();
  //   try {
  //     await axios.post("https://localhost:7195/api/Student/AddStudent", {
        
  //       stname: stname,
  //       course: course,
      
  //     });
  //     alert("Student Registation Successfully");
  //         setId("");
  //         setName("");
  //         setCourse("");
      
    
  //     Load();
  //   } catch (err) {
  //     alert(err);
  //   }
  // }
 
  // async function editStudent(students) {
  //   setName(students.stname);
  //   setCourse(students.course);
  
  //   setId(students.id);
  // }
 
  // async function DeleteStudent(id) {
  // await axios.delete("https://localhost:7195/api/Student/DeleteStudent/" + id);
  //  alert("Employee deleted Successfully");
  //  setId("");
  //  setName("");
  //  setCourse("");
  //  Load();
  // }
 
  // async function update(event) {
  //   event.preventDefault();
  //   try {
 
  // await axios.patch("https://localhost:7195/api/Student/UpdateStudent/"+ students.find((u) => u.id === id).id || id,
  //       {
  //       id: id,
  //       stname: stname,
  //       course: course,
 
  //       }
  //     );
  //     alert("Registation Updateddddd");
  //     setId("");
  //     setName("");
  //     setCourse("");
    
  //     Load();
  //   } catch (err) {
  //     alert(err);
  //   }
  // }
 
    return (
      <div>
        <h1>Games</h1>
      
      <table class="table table-dark" align="center">
        <thead>
          <tr>
            <th scope="col">Game Id</th>
            <th scope="col">Sport Id</th>
            <th scope="col">Start</th>
            <th scope="col">PredictedEnd</th>
            <th scope="col">CourtId</th>
          </tr>
        </thead>
        {games.map(function fn(game) {
          return (
            <tbody>
              <tr>
                <th scope="row">{game.gameId} </th>
                <td>{game.sportId}</td>
                <td>{game.start}</td>     
                <td>{game.precictedEnd}</td> 
                <td>{game.courtId}</td>                     
              </tr>
            </tbody>
          );
        })}
      </table>
        
      </div>
    );
  }

  export default GameComponent;
  