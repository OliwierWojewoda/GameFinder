import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useState } from "react";
import api from '../../api/GameFinder'
import { useNavigate } from "react-router-dom";

function Login() {
  const [password, setPwd] = useState('');
  const [email, setEmail] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post(
        '/Login',
        {
          user: {
            email: email,
            password: password
          }
        },
        {
          headers: { 'Content-Type': 'application/json' },
          withCredentials: true // Include credentials in the request
        }
      );
      const token = JSON.stringify(response.data.token);
            const userId = JSON.stringify(response.data.userId);

            localStorage.setItem('token', token);
            localStorage.setItem('userId', userId);

      navigate("/");
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mb-3" controlId="email">
        <Form.Label>Email address</Form.Label>
        <Form.Control value={email} onChange={(e) => setEmail(e.target.value)} type="email" placeholder="Enter email" />
      </Form.Group>

      <Form.Group className="mb-3" controlId="password">
        <Form.Label>Password</Form.Label>
        <Form.Control value={password} onChange={(e) => setPwd(e.target.value)} type="password" placeholder="Password" />
      </Form.Group>
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );
}

export default Login;