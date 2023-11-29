const User = require('../models/user'); // Replace with the actual import path
const jwt = require('jsonwebtoken'); // Import the jwt library

function GenerateToken(user) {

const payload = {

role: user.role,

id: user._id,

};

const token = jwt.sign(payload, 'adsfasdfjkh$#asdfasdf.adsfxc');

return token;

};

// Create a new user
async function createUser(req, res) {
    try {
        const user = await User.create(req.body);
        res.status(201).json(user);
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

async function login (req, res) {

    const { username, password } = req.body;
    
    try {
    
    const user = await User.findOne({ username});
    
    if (!user) return res.status(404).json({ error: 'User not found' });
    
    if (user.password != password) return res.status(401).json({ error: 'Invalid credentials' });
    
    var token = GenerateToken(user);
    
    return res.status(200).json({
    
    message: 'Logged in successfully',
    
    email: user.username,
    
    name: user.firstname,
    
    userid: user._id,
    
    token: token,
    });
    
    } catch (err) {
    
    return res.status(500).json({ message: err });
    
    }
    
    };

// Read all users
async function getUsers(req, res) {
    try {
        
        const users = await User.find();
        
        res.status(201).json(users);
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
    
}

// Read a specific user by ID
async function getUserById(req, res) {
    try {
        const user = await User.findById(req.params.id);
        if (!user) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(200).json(user);
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

async function checkUserExistence(req, res) {
    const { username, password } = req.body; // Assuming the username and password are sent in the request body

    try {
        // Search for a user with the given username and password
        const user = await User.findOne({ username, password });

        if (user) {
            // User with the provided username and password exists
            res.status(200).json({ message: 'User exists '+ user });
        } else {
            // User not found
            res.status(404).json({ error: 'User not found' });
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

// Update a user by ID
async function updateUser(req, res) {
    try {
        const user = await User.findByIdAndUpdate(req.params.id, req.body, { new: true });
        if (!user) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(200).json(user);
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

// Delete a user by ID
async function deleteUser(req, res) {
    try {
        
        const user = await User.findByIdAndDelete(req.params.id);
        if (!user) {
            res.status(404).json({ error: 'User not found' });
        } else {
            res.status(204).end();
        }
    } catch (err) {
        res.status(500).json({ error: err.message });
    }
}

module.exports = {
    createUser,
    getUsers,
    getUserById,
    updateUser,
    deleteUser,
    checkUserExistence,
    login
};
