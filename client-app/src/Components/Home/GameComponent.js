import Table from 'react-bootstrap/Table';
import axios from "axios";
import { useEffect, useState } from "react";
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Stack from 'react-bootstrap/Stack';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

function GameComponent() {
  const [games, setGame] = useState([]);
  const [gameId, setgameId] = useState("");
  const [sportId, setsportId] = useState("");
  const [start, setStart] = useState("");
  const [courtId, setCourtId] = useState("");
  const [PredictedEnd, setPredictedEnd] = useState("");
  const paths = {
    '1': require('../Images/1.jpg'),
    '2': require('../Images/2.jpg'),
    '3': require('../Images/3.jpg'),
    '4': require('../Images/4.jpg'),
  }
  useEffect(() => {
    (async () => await Load())();
  }, []);
  async function Load() {
    const result = await axios.get("https://localhost:7124/GetAllGames");
    setGame(result.data);
  }
  return (
    <div>
      <h1 className='m-2'>Upcoming Games</h1>
      <Stack direction="horizontal" gap={5} className='justify-content-center mb-2'>
        <DropdownButton id="dropdown-basic-button" title="Select City">
          <Dropdown.Item href="#/action-1">Katowice</Dropdown.Item>
          <Dropdown.Item href="#/action-2">Chorzów</Dropdown.Item>
          <Dropdown.Item href="#/action-3">Ruda Śląska</Dropdown.Item>
        </DropdownButton>
        <DropdownButton id="dropdown-basic-button" title="Select Sport">
          <Dropdown.Item href="#/action-1">Piłka Nożna</Dropdown.Item>
          <Dropdown.Item href="#/action-2">Koszykówka</Dropdown.Item>
          <Dropdown.Item href="#/action-3">Piłka ręczna</Dropdown.Item>
        </DropdownButton>
      </Stack>
      <div>
            {games.map(function fn(game) {
          return (
            <Card className="text-center mb-2">
            <Card.Header>{game.start.slice(0,16).replace('T',' ')}</Card.Header>
      <Card.Body className="d-flex flex-row justify-content-between align-items-center">
        <Card.Text ><img src={paths[game.sportId]} alt="Italian Trulli" width="150" height="150" ></img></Card.Text>
        <div className='d-flex flex-column justify-content-around'>
        <Card.Text> jest 15 ludzi </Card.Text>
        <Button variant="primary">Zapisz się</Button>
        </div>
        <Card.Text> {game.courtId} adresssssssssssssss </Card.Text>    
      </Card.Body> 
      </Card>
          );
        })}
      </div>
    </div>
  );
}

export default GameComponent;
