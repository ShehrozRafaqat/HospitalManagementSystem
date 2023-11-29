const express = require('express');

const router = express.Router();

const appController = require('../controllers/appController');

router.post('/add',appController.createAppointment);

router.delete('/delete/:id',appController.deleteAppointment);

router.get('/appointments',appController.getAppointments);

router.put('/update/:id',appController.updateAppointment);

router.get('/getAppointment',appController.getAppointmentById);

module.exports = router; 
