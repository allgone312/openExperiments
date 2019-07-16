package classroom_management;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;
import javax.swing.table.AbstractTableModel;
public class MyTableModel extends AbstractTableModel{
	public static Vector 	rowData;
	public static Vector 		columnNames;
	public MyTableModel(String value) {
		select(value);
	}
public MyTableModel(Vector rowData,Vector columnNames) {
		this.rowData=rowData;
		this.columnNames=columnNames;
	}
	public static Vector select(String value)
	{
		rowData=new Vector();
		columnNames=new Vector();
		Connection connection=null;
		PreparedStatement ps=null;
		ResultSet rs=null;
		String sql = null;
		if(value=="教师信息")
		{
			columnNames.add("教师编号");
			columnNames.add("教师姓名");
			columnNames.add("教授课程");
			columnNames.add("教师职称");
			sql="select * from TeacherInfo";
		}else if(value=="教室信息")
		{
			columnNames.add("教室编号");
			columnNames.add("教室设备");
			columnNames.add("教室容纳人数");
			columnNames.add("教室管理员编号");
			sql="select * from ClassInfo";
		}else if(value=="教室使用情况")
		{
			columnNames.add("教室编号");
			columnNames.add("上课开始时间");
			columnNames.add("结束时间");
			columnNames.add("教师编号");
			sql="select 教室编号, convert(varchar(20),上课开始时间,111),convert(varchar(20),上课开始时间,108),convert(varchar(20),结束时间,111) ,convert(varchar(20),结束时间,108), 教师编号 from ClassRoomInfo";
		}
		else if(value=="教室具体使用情况")
		{
			columnNames.add("教室编号");
			columnNames.add("教师编号");
			columnNames.add("教师姓名");
			columnNames.add("教授课程");
			columnNames.add("上课开始时间"); 
			columnNames.add("结束时间");
			columnNames.add("教师职称");
			columnNames.add("教室设备");
			columnNames.add("教室容纳人数");
			columnNames.add("教室管理员编号");
			sql="select ClassInfo.教室编号,TeacherInfo.教师编号,TeacherInfo.教师姓名,TeacherInfo.教授课程, convert(varchar(20),ClassRoomInfo.上课开始时间,111),convert(varchar(20),ClassRoomInfo.上课开始时间,108),convert(varchar(20),ClassRoomInfo.结束时间,111) ,convert(varchar(20),ClassRoomInfo.结束时间,108) ,TeacherInfo.教师职称,ClassInfo.教室设备,ClassInfo.教室容纳人数,ClassInfo.教室管理员编号 from ClassRoomInfo,TeacherInfo,ClassInfo  where ClassInfo.教室编号= ClassRoomInfo.教室编号   and  TeacherInfo.教师编号=ClassRoomInfo.教师编号";
		}
		try {
			//加载驱动
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
			//得到连接
	        connection=DriverManager.getConnection("jdbc:odbc:classManager", "sa", "songchao");
			//创建访问数据库接口
			ps=connection.prepareStatement(sql);
			rs=ps.executeQuery();
			if(value=="教师信息")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getString(3));
					tem.add(rs.getString(4));
					rowData.add(tem);
				}
			}else if(value=="教室信息")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getInt(3));
					tem.add(rs.getString(4));
					rowData.add(tem);
				}
			}else if(value=="教室使用情况")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2)+"/"+rs.getString(3));
					tem.add(rs.getString(4)+"/"+rs.getString(5));
					tem.add(rs.getString(6));
					rowData.add(tem);
				}
			}else if(value=="教室具体使用情况"){
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getString(3));
					tem.add(rs.getString(4));
					tem.add(rs.getString(5)+"/"+rs.getString(6));
					tem.add(rs.getString(7)+"/"+rs.getString(8));
					tem.add(rs.getString(9));
					tem.add(rs.getString(10));
					tem.add(rs.getInt(11));
					tem.add(rs.getString(12));
					rowData.add(tem);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}finally{
			try {
				rs.close();
				ps.close();
				connection.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		return rowData;
	}
	@Override
	public String getColumnName(int arg0) {
		return (String) columnNames.get(arg0);
	}
	@Override
	public int getColumnCount() {
		return columnNames.size();
	}
	@Override
	public int getRowCount() {
		return rowData.size();
	}	
@Override 
	public Object getValueAt(int rowIndex, int columnIndex) {
		return ((Vector)rowData.get(rowIndex)).get(columnIndex);
	}
}