import Table from 'react-bootstrap/Table';
import api from '../../api/GameFinder'
import { useEffect, useState } from "react";
 
function UsersListComponent() {
    const [users, setUsers] = useState([]);
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phone, setPhone] = useState('');
    const [birthdate, setBirthDate] = useState('');
    const [role, setRole] = useState('');
  useEffect(() => {
    (async () => await Load())();
  }, []);
  async function Load() {
    const result = await api.get("/GetAllUsers");
    setUsers(result.data);
  } 
    return (
      <div className='mt-3'>
        <h1>All Users</h1>
      
      <Table striped bordered hover variant="" align="center">
        <thead>
          <tr>
            <th scope="col">Email</th>
            <th scope="col">Name</th>
            <th scope="col">Surname</th>
            <th scope="col">Phone</th>
            <th scope="col">Birtdate</th>
            <th scope="col">Role</th>
          </tr>
        </thead>
        {users.map(function fn(user) {
          return (
            <tbody>
              <tr>
                <td>{user.email} </td>
                <td>{user.name}</td>
                <td>{user.surname}</td>     
                <td>{user.phone}</td> 
                <td>{user.birthday.slice(0,10)}</td>   
                <td>{user.roleId}</td>                  
              </tr>
            </tbody>
          );
        })}
      </Table>
      </div>
    );
  }

  export default UsersListComponent;
  