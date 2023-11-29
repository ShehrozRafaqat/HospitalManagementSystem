const mongoose = require('mongoose');

const appointmentSchema = new mongoose.Schema({
    
    type: String,
    date_time: String,
    doc:String,
    patient:String

},{timestamps:true});

module.exports = mongoose.model('Appointment',appointmentSchema);