<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Clients extends CI_Controller {

	var $clients = [ 
		[ 'id' => 0 , 'name' => 'Emmett', 'last_name' => 'Brown', 'email' => 'emmett@domain.com' ] ,
		[ 'id' => 1 , 'name' => 'Jennifer', 'last_name' => 'Parker', 'email' => 'jennifer@domain.com' ] ,
	];

	public function index()
	{
		//echo 'New controller index method';
		$this->load->view('clients/index', ['clients' => $this-> clients]);
	}

	public function details($id)
	{
		$this->load->view('clients/details');
		//echo 'Id: ' . $id;

	}
}
