import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useRef, useState, useEffect } from "react";
import axios from "axios";


function Register() {
    const [password, setPwd] = useState('');
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phone, setPhone] = useState('');
    const [birthdate, setBirthDate] = useState('');
    const [role, setRole] = useState('');
    const handleSubmit = async (e) => {
        try{
            const response = await axios.post('https://localhost:7124/Register',
            {
                newUser: {
                  email: email,
                  password: password,
                  name: name,
                  surname: surname,
                  phone: phone,
                  birthday: birthdate,
                  roleId: role
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
      <Form.Group className="mb-3" controlId="email">
        <Form.Label>Email address</Form.Label>
        <Form.Control value={email} onChange={(e) => setEmail(e.target.value)} type="email" placeholder="Enter email" />
      </Form.Group>

      <Form.Group className="mb-3" controlId="password">
        <Form.Label>Password</Form.Label>
        <Form.Control value={password} onChange={(e) => setPwd(e.target.value)} type="password" placeholder="Password" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="name">
        <Form.Label>Name</Form.Label>
        <Form.Control value={name} onChange={(e) => setName(e.target.value)} type="text" placeholder="Enter name" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="surname">
        <Form.Label>Surname</Form.Label>
        <Form.Control value={surname} onChange={(e) => setSurname(e.target.value)} type="text" placeholder="Enter surname" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="phone">
        <Form.Label>Phone</Form.Label>
        <Form.Control value={phone} onChange={(e) => setPhone(e.target.value)} type="tel" placeholder="Enter phone" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="birthdate">
        <Form.Label>Birthdate</Form.Label>
        <Form.Control value={birthdate} onChange={(e) => setBirthDate(e.target.value)} type="date" placeholder="Enter birthdate" />
      </Form.Group>
      <Form.Group className="mb-3" controlId="role">
        <Form.Label>Role</Form.Label>
        <Form.Control value={role} onChange={(e) => setRole(e.target.value)} type="text" placeholder="Choose 1 or 2" />
      </Form.Group>
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
    </div>
  );
}

export default Register;