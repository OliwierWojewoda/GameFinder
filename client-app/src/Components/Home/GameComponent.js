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
  const [postalCode, setpostalCode] = useState('');
  const [city, setCity] = useState('');
  const [street, setStreet] = useState('');
  const paths = {
    '1': require('../Images/1.jpg'),
    '2': require('../Images/2.jpg'),
    '3': require('../Images/3.jpg'),
    '4': require('../Images/4.jpg'),
  }
  const [addresses, setAddresses] = useState([]);
  async function FindAddress(courtIdToFind){
    const result = await axios.get("https://localhost:7124/GetAddress"
    , { params: { courtId: courtIdToFind } });
    return result.data
  }
  useEffect(() => {
    (async () => await Load())();
  }, []);
  async function Load() {
    const result = await axios.get("https://localhost:7124/GetAllGames");
    setGame(result.data);
    const addressesres = await Promise.all(result.data.map(game => FindAddress(game.courtId)));
    console.log(await Promise.all(result.data.map(game => FindAddress(game.courtId))))
    setAddresses(addressesres);
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
      {games.map((game,index) => {
          return (
            <Card className="text-center mb-2">
            <Card.Header>{game.start.slice(0,16).replace('T',' ')}</Card.Header>
      <Card.Body className="d-flex flex-row justify-content-between align-items-center">
        <Card.Text ><img src={paths[game.sportId]} alt="Italian Trulli" width="150" height="150" ></img></Card.Text>
        <div className='d-flex flex-column justify-content-around'>
        <Card.Text> jest 15 ludzi </Card.Text>
        <Button variant="primary">Zapisz się</Button>
        </div>
        <div className='m-5'>       
        <Card.Text>
          {addresses[index] && `${addresses[index].city}`} 
        </Card.Text> 
        <Card.Text>
          {addresses[index] && `${addresses[index].postalCode}`} 
        </Card.Text>  
        <Card.Text>
          {addresses[index] && `${addresses[index].street}`} 
        </Card.Text>     
        </div>
      </Card.Body> 
      </Card>
          );
        })}
      </div>
    </div>
  );
}

export default GameComponent;
