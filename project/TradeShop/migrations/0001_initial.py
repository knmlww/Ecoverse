# Generated by Django 3.2.7 on 2021-09-30 19:41

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Exchange',
            fields=[
                ('regtime', models.DateTimeField(auto_now_add=True, primary_key=True, serialize=False)),
                ('item_code', models.CharField(max_length=10)),
                ('price', models.IntegerField(default=0)),
                ('name', models.CharField(max_length=50)),
            ],
        ),
    ]
