# Generated by Django 3.2.7 on 2021-09-22 05:16

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('account', '0005_user_unlock'),
    ]

    operations = [
        migrations.AddField(
            model_name='user',
            name='badge',
            field=models.CharField(max_length=40, null=True),
        ),
    ]
