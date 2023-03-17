const express = require('express');
const router = express.Router();
const {newAddvert, allAddvert, findAddvert,
       updateAddvert, deleteAddvert, getRandomAddvert } = require('../dbAccess/dbtrans')

router.post('/newAddvert/:Custid', newAddvert);

router.get('/allAddvert', allAddvert); 

router.get('/custAddvert/:id', findAddvert); 

router.put('/upaddvert/:id', updateAddvert); 

router.delete('/deladdvert/:id', deleteAddvert); 

router.get("/getRandomAddvert",getRandomAddvert);







module.exports = router; 