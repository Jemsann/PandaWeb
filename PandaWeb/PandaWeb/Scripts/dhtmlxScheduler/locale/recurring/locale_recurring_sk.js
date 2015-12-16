/*
@license
dhtmlxScheduler.Net v.3.3.12 

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){e.__recurring_template='<div class="dhx_form_repeat"><form><div class="dhx_repeat_left"><label><input class="dhx_repeat_radio" type="radio" name="repeat" value="day" />Denne</label><br /><label><input class="dhx_repeat_radio" type="radio" name="repeat" value="week"/>Týždenne</label><br /><label><input class="dhx_repeat_radio" type="radio" name="repeat" value="month" checked />Mesaène</label><br /><label><input class="dhx_repeat_radio" type="radio" name="repeat" value="year" />Roène</label></div><div class="dhx_repeat_divider"></div><div class="dhx_repeat_center"><div style="display:none;" id="dhx_repeat_day"><label><input class="dhx_repeat_radio" type="radio" name="day_type" value="d"/>Každý</label><input class="dhx_repeat_text" type="text" name="day_count" value="1" />deò<br /><label><input class="dhx_repeat_radio" type="radio" name="day_type" checked value="w"/>Každý prac. deò</label></div><div style="display:none;" id="dhx_repeat_week">Opakova každý<input class="dhx_repeat_text" type="text" name="week_count" value="1" />týždeò v dòoch:<br /><table class="dhx_repeat_days"><tr><td><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="1" />Pondelok</label><br /><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="4" />Štvrtok</label></td><td><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="2" />Utorok</label><br /><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="5" />Piatok</label></td><td><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="3" />Streda</label><br /><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="6" />Sobota</label></td><td><label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="0" />Nede¾a</label><br /><br /></td></tr></table></div><div id="dhx_repeat_month"><label><input class="dhx_repeat_radio" type="radio" name="month_type" value="d"/>Opakova</label><input class="dhx_repeat_text" type="text" name="month_day" value="1" />deò každý<input class="dhx_repeat_text" type="text" name="month_count" value="1" />mesiac<br /><label><input class="dhx_repeat_radio" type="radio" name="month_type" checked value="w"/>On</label><input class="dhx_repeat_text" type="text" name="month_week2" value="1" /><select name="month_day2"><option value="1" selected >Pondelok<option value="2">Utorok<option value="3">Streda<option value="4">Štvrtok<option value="5">Piatok<option value="6">Sobota<option value="0">Nede¾a</select>každý<input class="dhx_repeat_text" type="text" name="month_count2" value="1" />mesiac<br /></div><div style="display:none;" id="dhx_repeat_year"><label><input class="dhx_repeat_radio" type="radio" name="year_type" value="d"/>Každý</label><input class="dhx_repeat_text" type="text" name="year_day" value="1" />deò<select name="year_month"><option value="0" selected >Január<option value="1">Február<option value="2">Marec<option value="3">Apríl<option value="4">Máj<option value="5">Jún<option value="6">Júl<option value="7">August<option value="8">September<option value="9">Október<option value="10">November<option value="11">December</select>mesiac<br /><label><input class="dhx_repeat_radio" type="radio" name="year_type" checked value="w"/>On</label><input class="dhx_repeat_text" type="text" name="year_week2" value="1" /><select name="year_day2"><option value="1" selected >Pondelok<option value="2">Utorok<option value="3">Streda<option value="4">Štvrtok<option value="5">Piatok<option value="6">Sobota<option value="7">Nede¾a</select>poèas<select name="year_month2"><option value="0" selected >Január<option value="1">Február<option value="2">Marec<option value="3">Apríl<option value="4">Máj<option value="5">Jún<option value="6">Júl<option value="7">August<option value="8">September<option value="9">Október<option value="10">November<option value="11">December</select><br /></div></div><div class="dhx_repeat_divider"></div><div class="dhx_repeat_right"><label><input class="dhx_repeat_radio" type="radio" name="end" checked/>Bez dátumu ukonèenia</label><br /><label><input class="dhx_repeat_radio" type="radio" name="end" />Po</label><input class="dhx_repeat_text" type="text" name="occurences_count" value="1" />udalostiach<br /><label><input class="dhx_repeat_radio" type="radio" name="end" />Ukonèi</label><input class="dhx_repeat_date" type="text" name="date_of_end" value="'+e.config.repeat_date_of_end+'" /><br /></div></form></div><div style="clear:both"></div>';

});