import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import {useState} from "react";
import axios from "axios";


function AddCourt() {
    const [city, setCity] = useState('');
    const [street, setStreet] = useState('');
    const [postal_Code, setPostal_Code] = useState('');
    const [courtType, setCourtType] = useState('');
    const handleSubmit = async (e) => {
        try{
            const response = await axios.post('https://localhost:7124/AddCourt',
            {
                newCourtDto: {
                    city: city,
                    street: street,
                    postal_Code: postal_Code,
                    courtType: courtType,
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
        <Form.Label>City</Form.Label>
        <Form.Control value={city} onChange={(e) => setCity(e.target.value)} type="text" placeholder="City" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="predictedEnd">
        <Form.Label>Postal Code</Form.Label>
        <Form.Control value={postal_Code} onChange={(e) => setPostal_Code(e.target.value)} type="text" placeholder="Postal Code" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="courtId">
        <Form.Label>Street</Form.Label>
        <Form.Control value={street} onChange={(e) => setStreet(e.target.value)} type="text" placeholder="Street" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="courtId">
        <Form.Label>Court Type</Form.Label>
        <Form.Control value={courtType} onChange={(e) => setCourtType(e.target.value)} type="text" placeholder="Court Type" />
      </Form.Group>   
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
    </div>
  );
}

export default AddCourt;