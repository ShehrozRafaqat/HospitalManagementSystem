const express = require('express');
const auth_middleware = require('../utils/auth_middleware');

const router = express.Router();

const userController = require('../controllers/userController');

router.post('/add',userController.createUser);

router.delete('/delete/:id',userController.deleteUser);

router.get('/users',userController.getUsers);

router.put('/update/:id',userController.updateUser);

router.get('/getUser',userController.login);

module.exports = router; 
