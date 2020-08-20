<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Home extends CI_Controller {

	public function Index()
	{
		//echo 'New controller index method';
		$this->load->view('home/Index');
	}

	public function QuienesSomos()
	{
		//echo 'New controller index method';
		$this->load->view('home/QuienesSomos');
	}

	public function Catalogo()
	{
		//echo 'New controller index method';
		$this->load->view('home/Catalogo');
	}

	public function Blog()
	{
		//echo 'New controller index method';
		$this->load->view('home/Blog');
	}

	public function Ingreso()
	{
		//echo 'New controller index method';
		$this->load->view('home/Ingreso');
	}

	public function Registro()
	{
		//echo 'New controller index method';
		$this->load->view('home/Registro');
	}
}
