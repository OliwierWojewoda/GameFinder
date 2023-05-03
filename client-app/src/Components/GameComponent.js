import Table from 'react-bootstrap/Table';
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
  }
    return (
      <div>
        <h1>Games</h1>
      
      <Table striped bordered hover align="center">
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
                <td>{game.gameId} </td>
                <td>{game.sportId}</td>
                <td>{game.start.slice(0,16).replace('T',' ')}</td>     
                <td>{game.precictedEnd.slice(0,16).replace('T',' ')}</td> 
                <td>{game.courtId}</td>                     
              </tr>
            </tbody>
          );
        })}
      </Table>
        
      </div>
    );
  }

  export default GameComponent;
  