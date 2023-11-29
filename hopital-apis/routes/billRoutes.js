const express = require('express');

const router = express.Router();

const appController = require('../controllers/billController');

router.post('/add',appController.createBill);

router.delete('/delete/:id',appController.deleteBill);

router.get('/bills',appController.getBills);

router.put('/update/:id',appController.updateBill);

router.get('/getBill',appController.getBillById);

module.exports = router; 
