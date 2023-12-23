from flask_wtf import FlaskForm
from wtforms import SelectField, StringField, SubmitField, TextAreaField
from wtforms.validators import DataRequired


class TodoForm(FlaskForm):
  name = StringField('Заголовок', validators=[DataRequired()])
  description = TextAreaField('Описание', validators=[DataRequired()])
  completed = SelectField('Статус', choices=[("False", "Не выполнено"), ("True", "Выполнено")], validators=[DataRequired()])
  submit = SubmitField("Добавить задачу")
