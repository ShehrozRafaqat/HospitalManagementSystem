const { application } = require('express');
const App = require('../models/bill'); // Replace with the actual import path

function GenerateToken(user) {

const payload = {

role: user.role,

id: user._id,

};

const token = jwt.sign(payload, 'adsfasdfjkh$#asdfasdf.adsfxc');

return token;

};

// Create a new user
async function createBill(req, res) {
    try {
        const app = await App.create(req.body);
        res.status(201).json(app);
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}


// Read all users
async function getBills(req, res) {
    try {
        
        const appointments = await App.find();
        
        res.status(201).json(appointments);
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
    
}

// Read a specific user by ID
async function getBillById(req, res) {
    try {
        const app = await App.findById(req.params.id);
        if (!application) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(200).json(app);
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}


// Update a user by ID
async function updateBill(req, res) {
    try {
        const app = await App.findByIdAndUpdate(req.params.id, req.body, { new: true });
        if (!app) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(200).json(app);
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

// Delete a user by ID
async function deleteBill(req, res) {
    try {
        
        const app = await App.findByIdAndDelete(req.params.id);
        if (!app) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(204).end();
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

module.exports = {
    createBill,
    getBillById,
    getBills,
    deleteBill,
    updateBill
};
