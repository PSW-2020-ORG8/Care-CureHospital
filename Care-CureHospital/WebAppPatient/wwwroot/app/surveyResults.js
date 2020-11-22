Vue.component("surveyResults", {
	data: function () {
		return {
			surveyResults: []
		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollSurvey">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="pictures/clinic.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
				<li><a href="#/">Pretraga dokumenata</a></li>
				<li class="active"><a href="#/">Anketa</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="pictures/menuIcon.png" />
	        	<img id="userIcon" src="pictures/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a >Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
		</div>
		
	<div class="survey-vertical-line"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li class="active" ><a href="#/">Objavljeni utisci</a></li></div><br/>
		    <div><li><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br/>
			<div><li><a href="#/postFeedback">Ostavite utisak</a></li></div><br/>
	     </ul>
	 </div>

	
	<div class="survey-questions">	
		<h3 class = "doctor-qestions-title">Pitanja o doktoru kod kog je izvršen pregled:</h3> 
		<table class="questions-about-doctor">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
            <td v-model="textOfQuestion1">Ljubaznost doktora prema pacijentu</td>
            <template v-for="grade in this.surveyResults[0].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[0].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion2">Posvećenost doktora pacijentu</td>
			<template v-for="grade in this.surveyResults[1].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[1].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion3">Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja</td>
			<template v-for="grade in this.surveyResults[2].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[2].averageGrade}}</td>
			</tr>
		</table> 
		<h3 class = "medicalstaff-qestions-title">Pitanja o medicinskom osoblju bolnice:</h3> 
		<table class="questions-about-medicalstaff">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
			<td v-model="textOfQuestion4">Ljubaznost medicinskog osoblja prema pacijentu</td>
			<template v-for="grade in this.surveyResults[3].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[3].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion5">Posvećenost medicinskog osoblja pacijentu</td>
			<template v-for="grade in this.surveyResults[4].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[4].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion6">Profesionalizam u obavljanju svoji duznosti medicinskog osoblja</td>
			<template v-for="grade in this.surveyResults[5].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[5].averageGrade}}</td>
			</tr>
		</table> 
		<h3 class = "hospital-qestions-title">Pitanja o radu bolnice:</h3> 
		<table class="questions-about-hospital">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
			<td v-model="textOfQuestion7">Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici</td>
			<template v-for="grade in this.surveyResults[6].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[6].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion8">Higijena unutar bolnice</td>
			<template v-for="grade in this.surveyResults[7].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[7].averageGrade}}</td>
			</tr>
			<tr>
			<td v-model="textOfQuestion9">Opremljenost bolnice</td>
			<template v-for="grade in this.surveyResults[8].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{this.surveyResults[8].averageGrade}}</td>
			</tr>
		</table> 
		

	</div>
	
	 
	 

	     
	</div>	  
	</div>
        
	`
	,
	methods: {

	},
	computed: {

	},
	mounted() {

		axios.get('api/survey/getSurveyResults').then(response => {
					this.surveyResults = response.data;
				});

	}

});