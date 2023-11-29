const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    
    username: String,
    password: String,
    role:Number

},{timestamps:true});

module.exports = mongoose.model('User',userSchema);