import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import {useState} from "react";
import axios from "axios";


function Addgame() {
    const [sportId, setSportId] = useState('');
    const [start, setStart] = useState('');
    const [predictedEnd, setPredictedEnd] = useState('');
    const [courtId, setCourtId] = useState('');
    const handleSubmit = async (e) => {
        try{
            const response = await axios.post('https://localhost:7124/AddGame',
            {
                newGameDto: {
                    sportId: sportId,
                    start: start,
                    precictedEnd: predictedEnd,
                    courtId: courtId,
                }},
                {
                    headers: { 'Content-Type': 'application/json' }
                }              
            ); 
           await console.log(response); 
        }        
        catch(error){
            console.log(error);
        }
    }

  return (
    <div className="m-3">
    <Form onSubmit={handleSubmit} >
      <Form.Group className="mb-3" controlId="start">
        <Form.Label>Start</Form.Label>
        <Form.Control value={start} onChange={(e) => setStart(e.target.value)} type="date" placeholder="Enter email" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="predictedEnd">
        <Form.Label>Predicted End</Form.Label>
        <Form.Control value={predictedEnd} onChange={(e) => setPredictedEnd(e.target.value)} type="date" placeholder="Password" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="courtId">
        <Form.Label>Court</Form.Label>
        <Form.Control value={courtId} onChange={(e) => setCourtId(e.target.value)} type="number" placeholder="Password" />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Select Sport</Form.Label>
        <Form.Select onChange={(e) => setSportId(e.target.value)}>
          <option value="1">Soccer</option>
          <option value="2">Basketball</option>
          <option value="3">Volleyball</option>
          <option value="4">Tennis</option>
        </Form.Select>
      </Form.Group>    
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
    </div>
  );
}

export default Addgame;